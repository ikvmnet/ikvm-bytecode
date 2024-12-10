using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace IKVM.ByteCode.Buffers
{

    /// <summary>
    /// Manages a set of allocated buffers, providing fast append and prepend operations.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    public partial class BlobBuilder
    {

        /// <summary>
        /// Default chunk size.
        /// </summary>
        internal const int DefaultChunkSize = 256;

        /// <summary>
        /// Must be at least the size of the largest primitive type we write atomically.
        /// </summary>
        internal const int MinChunkSize = 16;

        /// <summary>
        /// Builders are linked like so:
        ///
        /// [1:first]->[2]->[3:last]<-[4:head]
        ///     ^_______________|
        ///
        /// In this case the content represented is a sequence (1,2,3,4).
        /// This structure optimizes for append write operations and sequential enumeration from the start of the chain.
        /// Data can only be written to the head node. Other nodes are "frozen".
        /// </summary>
        BlobBuilder _nextOrPrevious;

        /// <summary>
        /// Gets the first chunk.
        /// </summary>
        BlobBuilder FirstChunk => _nextOrPrevious._nextOrPrevious;

        /// <summary>
        /// The sum of lengths of all preceding chunks (not including the current chunk),
        /// or a difference between original buffer length of a builder that was linked as a suffix to another builder,
        /// and the current length of the buffer(not that the buffers are swapped when suffix linking).
        /// </summary>
        int _previousLengthOrFrozenSuffixLengthDelta;

        /// <summary>
        /// Data of this chunk.
        /// </summary>
        byte[] _buffer;

        /// <summary>
        /// The length of data in the buffer in lower 31 bits.
        /// Head: highest bit is 0, length may be 0.
        /// Non-head: highest bit is 1, lower 31 bits are not all 0.
        /// </summary>
        uint _length;

        const uint IsFrozenMask = 0x80000000;

        internal bool IsHead => (_length & IsFrozenMask) == 0;

        int Length => (int)(_length & ~IsFrozenMask);

        uint FrozenLength => _length | IsFrozenMask;

        Span<byte> Span => _buffer.AsSpan(0, Length);

        /// <summary>
        /// Initialies a new instance.
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public BlobBuilder(int capacity = DefaultChunkSize)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            _nextOrPrevious = this;
            _buffer = new byte[Math.Max(MinChunkSize, capacity)];
        }

        /// <summary>
        /// Allocates a chunk of data within the builder.
        /// </summary>
        /// <param name="minimalSize"></param>
        /// <returns></returns>
        protected virtual BlobBuilder AllocateChunk(int minimalSize)
        {
            return new BlobBuilder(Math.Max(_buffer.Length, minimalSize));
        }

        protected virtual void FreeChunk()
        {
            // nop
        }

        /// <summary>
        /// Clears the builder.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Clear()
        {
            if (IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            // Swap buffer with the first chunk.
            // Note that we need to keep holding on all allocated buffers,
            // so that builders with custom allocator can release them.
            var first = FirstChunk;
            if (first != this)
            {
                var firstBuffer = first._buffer;
                first._length = FrozenLength;
                first._buffer = _buffer;
                _buffer = firstBuffer;
            }

            // free all chunks except for the current one
            foreach (var chunk in GetChunks())
                if (chunk != this)
                    chunk.ClearAndFreeChunk();

            ClearChunk();
        }

        protected void Free()
        {
            Clear();
            FreeChunk();
        }

        internal void ClearChunk()
        {
            _length = 0;
            _previousLengthOrFrozenSuffixLengthDelta = 0;
            _nextOrPrevious = this;
        }

        /// <summary>
        /// Checks that the blob builder state is valid.
        /// </summary>
        [Conditional("DEBUG")]
        void CheckInvariants()
        {
            Debug.Assert(_buffer != null);
            Debug.Assert(Length >= 0 && Length <= _buffer!.Length);
            Debug.Assert(_nextOrPrevious != null);

            if (IsHead)
            {
                Debug.Assert(_previousLengthOrFrozenSuffixLengthDelta >= 0);

                // last chunk:
                int totalLength = 0;
                foreach (var chunk in GetChunks())
                {
                    Debug.Assert(chunk.IsHead || chunk.Length > 0);
                    totalLength += chunk.Length;
                }

                Debug.Assert(totalLength == Count);
            }
        }

        /// <summary>
        /// Gets the count of written bytes to the builder.
        /// </summary>
        public int Count => _previousLengthOrFrozenSuffixLengthDelta + Length;

        int PreviousLength
        {
            get
            {
                Debug.Assert(IsHead);
                return _previousLengthOrFrozenSuffixLengthDelta;
            }
            set
            {
                Debug.Assert(IsHead);
                _previousLengthOrFrozenSuffixLengthDelta = value;
            }
        }

        protected int FreeBytes => _buffer.Length - Length;

        protected internal int ChunkCapacity => _buffer.Length;

        internal BlobBuilderEnumerable GetChunks()
        {
            if (IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            return new BlobBuilderEnumerable(this);
        }

        /// <summary>
        /// Returns a sequence of all blobs that represent the content of the builder.
        /// </summary>
        /// <exception cref="InvalidOperationException">Content is not available, the builder has been linked with another one.</exception>
        public BlobEnumerable GetBlobs()
        {
            if (IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            return new BlobEnumerable(this);
        }

        /// <summary>
        /// Compares the current content of this writer with another one.
        /// </summary>
        /// <exception cref="InvalidOperationException">Content is not available, the builder has been linked with another one.</exception>
        public bool ContentEquals(BlobBuilder other)
        {
            if (IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            if (ReferenceEquals(this, other))
                return true;

            if (other == null)
                return false;

            if (other.IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            if (Count != other.Count)
                return false;

            var leftEnumerator = GetChunks();
            var rightEnumerator = other.GetChunks();
            var leftStart = 0;
            var rightStart = 0;

            var leftContinues = leftEnumerator.MoveNext();
            var rightContinues = rightEnumerator.MoveNext();

            while (leftContinues && rightContinues)
            {
                Debug.Assert(leftStart == 0 || rightStart == 0);

                var left = leftEnumerator.Current;
                var right = rightEnumerator.Current;

                int minLength = Math.Min(left.Length - leftStart, right.Length - rightStart);
                if (left._buffer.AsSpan(leftStart, minLength).SequenceEqual(right._buffer.AsSpan(rightStart, minLength)) == false)
                    return false;

                leftStart += minLength;
                rightStart += minLength;

                // nothing remains in left chunk to compare:
                if (leftStart == left.Length)
                {
                    leftContinues = leftEnumerator.MoveNext();
                    leftStart = 0;
                }

                // nothing remains in left chunk to compare:
                if (rightStart == right.Length)
                {
                    rightContinues = rightEnumerator.MoveNext();
                    rightStart = 0;
                }
            }

            return leftContinues == rightContinues;
        }

        /// <summary>
        /// Returns the written bytes as a single array.
        /// </summary>
        /// <exception cref="InvalidOperationException">Content is not available, the builder has been linked with another one.</exception>
        public byte[] ToArray()
        {
            return ToArray(0, Count);
        }

        /// <summary>
        /// Returns the written bytes for the specified range as a single array.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Range specified by <paramref name="start"/> and <paramref name="byteCount"/> falls outside of the bounds of the buffer content.</exception>
        /// <exception cref="InvalidOperationException">Content is not available, the builder has been linked with another one.</exception>
        public byte[] ToArray(int start, int byteCount)
        {
            ValidateRange(Count, start, byteCount, nameof(byteCount));

            var result = new byte[byteCount];

            int chunkStart = 0;
            int bufferStart = start;
            int bufferEnd = start + byteCount;
            foreach (var chunk in GetChunks())
            {
                int chunkEnd = chunkStart + chunk.Length;
                Debug.Assert(bufferStart >= chunkStart);

                if (chunkEnd > bufferStart)
                {
                    int bytesToCopy = Math.Min(bufferEnd, chunkEnd) - bufferStart;
                    Debug.Assert(bytesToCopy >= 0);

                    Array.Copy(chunk._buffer, bufferStart - chunkStart, result, bufferStart - start, bytesToCopy);
                    bufferStart += bytesToCopy;

                    if (bufferStart == bufferEnd)
                    {
                        break;
                    }
                }

                chunkStart = chunkEnd;
            }

            Debug.Assert(bufferStart == bufferEnd);

            return result;
        }

        /// <summary>
        /// Write the contents of this blob builder to the given <see cref="Stream"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="destination"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Content is not available, the builder has been linked with another one.</exception>
        public void WriteContentTo(Stream destination)
        {
            if (destination is null)
                throw new ArgumentNullException(nameof(destination));

            foreach (var chunk in GetChunks())
                destination.Write(chunk._buffer, 0, chunk.Length);
        }

        /// <summary>
        /// Writes the contents of this blob builder to the given <see cref="BlobBuilder"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="destination"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Content is not available, the builder has been linked with another one.</exception>
        public void WriteContentTo(BlobBuilder destination)
        {
            if (destination is null)
                throw new ArgumentNullException(nameof(destination));

            foreach (var chunk in GetChunks())
                destination.WriteBytes(chunk.Span);
        }

        /// <exception cref="ArgumentNullException"><paramref name="prefix"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public void LinkPrefix(BlobBuilder prefix)
        {
            if (prefix is null)
                throw new ArgumentNullException(nameof(prefix));

            // TODO: consider copying data from right to left while there is space

            if (!prefix.IsHead || !IsHead)
                throw new InvalidOperationException("Builder already linked.");

            // avoid chaining empty chunks:
            if (prefix.Count == 0)
            {
                prefix.ClearAndFreeChunk();
                return;
            }

            PreviousLength += prefix.Count;

            // prefix is not a head anymore:
            prefix._length = prefix.FrozenLength;

            // First and last chunks:
            //
            // [PrefixFirst]->[]->[PrefixLast] <- [prefix]    [First]->[]->[Last] <- [this]
            //       ^_________________|                          ^___________|
            //
            // Degenerate cases:
            // this == First == Last and/or prefix == PrefixFirst == PrefixLast.
            var first = FirstChunk;
            var prefixFirst = prefix.FirstChunk;
            var last = _nextOrPrevious;
            var prefixLast = prefix._nextOrPrevious;

            // Relink like so:
            // [PrefixFirst]->[]->[PrefixLast] -> [prefix] -> [First]->[]->[Last] <- [this]
            //      ^________________________________________________________|

            _nextOrPrevious = (last != this) ? last : prefix;
            prefix._nextOrPrevious = (first != this) ? first : (prefixFirst != prefix) ? prefixFirst : prefix;

            if (last != this)
                last._nextOrPrevious = (prefixFirst != prefix) ? prefixFirst : prefix;

            if (prefixLast != prefix)
                prefixLast._nextOrPrevious = prefix;

            prefix.CheckInvariants();
            CheckInvariants();
        }

        /// <summary>
        /// Links the given <paramref name="suffix"/> to the end of this <see cref="BlobBuilder"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="suffix"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public void LinkSuffix(BlobBuilder suffix)
        {
            if (suffix is null)
                throw new ArgumentNullException(nameof(suffix));

            // TODO: consider copying data from right to left while there is space

            if (!IsHead || !suffix.IsHead)
                throw new InvalidOperationException("Builder already linked.");

            // avoid chaining empty chunks:
            if (suffix.Count == 0)
            {
                suffix.ClearAndFreeChunk();
                return;
            }

            var isEmpty = Count == 0;

            // swap buffers of the heads:
            var suffixBuffer = suffix._buffer;
            var suffixLength = suffix._length;
            var suffixPreviousLength = suffix.PreviousLength;
            var oldSuffixLength = suffix.Length;
            suffix._buffer = _buffer;
            suffix._length = FrozenLength; // suffix is not a head anymore
            _buffer = suffixBuffer;
            _length = suffixLength;

            PreviousLength += suffix.Length + suffixPreviousLength;

            // Update the _previousLength of the suffix so that suffix.Count = suffix._previousLength + suffix.Length doesn't change.
            // Note that the resulting previous length might be negative.
            // The value is not used, other than for calculating the value of Count property.
            suffix._previousLengthOrFrozenSuffixLengthDelta = suffixPreviousLength + oldSuffixLength - suffix.Length;

            if (!isEmpty)
            {
                // First and last chunks:
                //
                // [First]->[]->[Last] <- [this]    [SuffixFirst]->[]->[SuffixLast]  <- [suffix]
                //    ^___________|                       ^_________________|
                //
                // Degenerate cases:
                // this == First == Last and/or suffix == SuffixFirst == SuffixLast.
                var first = FirstChunk;
                var suffixFirst = suffix.FirstChunk;
                var last = _nextOrPrevious;
                var suffixLast = suffix._nextOrPrevious;

                // Relink like so:
                // [First]->[]->[Last] -> [suffix] -> [SuffixFirst]->[]->[SuffixLast]  <- [this]
                //    ^_______________________________________________________|
                _nextOrPrevious = suffixLast;
                suffix._nextOrPrevious = (suffixFirst != suffix) ? suffixFirst : (first != this) ? first : suffix;

                if (last != this)
                    last._nextOrPrevious = suffix;

                if (suffixLast != suffix)
                    suffixLast._nextOrPrevious = (first != this) ? first : suffix;
            }

            CheckInvariants();
            suffix.CheckInvariants();
        }

        void AddLength(int value)
        {
            _length += (uint)value;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        void Expand(int newLength)
        {
            // TODO: consider converting the last chunk to a smaller one if there is too much empty space left

            // May happen only if the derived class attempts to write to a builder that is not last,
            // or if a builder prepended to another one is not discarded.
            if (IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            var newChunk = AllocateChunk(Math.Max(newLength, MinChunkSize));
            if (newChunk.ChunkCapacity < newLength)
                throw new InvalidOperationException("Returned builder size is too small.");

            var newBuffer = newChunk._buffer;

            if (_length == 0)
            {
                // If the first write into an empty buffer needs more space than the buffer provides, swap the buffers.
                newChunk._buffer = _buffer;
                _buffer = newBuffer;
            }
            else
            {
                // Otherwise append the new buffer.
                var last = _nextOrPrevious;
                var first = FirstChunk;

                if (last == this)
                {
                    _nextOrPrevious = newChunk; // single chunk in the chain
                }
                else
                {
                    newChunk._nextOrPrevious = first;
                    last._nextOrPrevious = newChunk;
                    _nextOrPrevious = newChunk;
                }

                newChunk._buffer = _buffer;
                newChunk._length = FrozenLength;
                newChunk._previousLengthOrFrozenSuffixLengthDelta = PreviousLength;

                _buffer = newBuffer;
                PreviousLength += Length;
                _length = 0;
            }

            CheckInvariants();
        }

        /// <summary>
        /// Reserves a contiguous block of bytes.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="byteCount"/> is negative.</exception>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public Blob ReserveBytes(int byteCount)
        {
            if (byteCount < 0)
                throw new ArgumentOutOfRangeException(nameof(byteCount));

            var start = ReserveBytesImpl(byteCount);
            return new Blob(_buffer, start, byteCount);
        }

        /// <summary>
        /// Reserves the specified number of bytes in the blob.
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        int ReserveBytesImpl(int byteCount)
        {
            Debug.Assert(byteCount >= 0);

            // If write is attempted to a frozen builder we fall back
            // to expand where an exception is thrown:
            var result = _length;
            if (result > _buffer.Length - byteCount)
            {
                Expand(byteCount);
                result = 0;
            }

            _length = result + (uint)byteCount;
            return (int)result;
        }

        int ReserveBytesPrimitive(int byteCount)
        {
            // If the primitive doesn't fit to the current chuck we'll allocate a new chunk that is at least MinChunkSize.
            // That chunk has to fit the primitive otherwise we might keep allocating new chunks and never end up with one that fits.
            Debug.Assert(byteCount <= MinChunkSize);
            return ReserveBytesImpl(byteCount);
        }

        /// <summary>
        /// Throws an exception if the given range information is improper.
        /// </summary>
        /// <param name="bufferLength"></param>
        /// <param name="start"></param>
        /// <param name="byteCount"></param>
        /// <param name="byteCountParameterName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void ValidateRange(int bufferLength, int start, int byteCount, string byteCountParameterName)
        {
            if (start < 0 || start > bufferLength)
                throw new ArgumentOutOfRangeException(nameof(start));
            if (byteCount < 0 || byteCount > bufferLength - start)
                throw new ArgumentOutOfRangeException(nameof(byteCountParameterName));
        }

        /// <summary>
        /// Writes the bytes from the specified array to <paramref name="buffer">.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        /// <param name="byteCount"></param>
        static void WriteBytesTo(byte[] buffer, int start, byte value, int byteCount)
        {
            Debug.Assert(buffer.Length > 0);
            new Span<byte>(buffer, start, byteCount).Fill(value);
        }

        /// <summary>
        /// Writes the specified byte value <paramref name="byteCount"/> number of times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="byteCount"/> is negative.</exception>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public void WriteBytes(byte value, int byteCount)
        {
            if (byteCount < 0)
                throw new ArgumentOutOfRangeException(nameof(byteCount));
            if (IsHead == false)
                throw new InvalidOperationException("Builder is already linked.");

            var bytesToCurrent = Math.Min(FreeBytes, byteCount);

            WriteBytesTo(_buffer, Length, value, bytesToCurrent);
            AddLength(bytesToCurrent);

            var remaining = byteCount - bytesToCurrent;
            if (remaining > 0)
            {
                Expand(remaining);
                WriteBytesTo(_buffer, 0, value, remaining);
                AddLength(remaining);
            }
        }

        /// <summary>
        /// Writes the specified number of bytes from the given pointer.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="byteCount"/> is negative.</exception>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public unsafe void WriteBytes(byte* buffer, int byteCount)
        {
            if (buffer is null)
                throw new ArgumentNullException(nameof(buffer));
            if (byteCount < 0)
                throw new ArgumentOutOfRangeException(nameof(byteCount));
            if (IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            WriteBytesUnchecked(new ReadOnlySpan<byte>(buffer, byteCount));
        }

        /// <summary>
        /// Writes the given bytes from the specified buffer.
        /// </summary>
        /// <param name="buffer"></param>
        void WriteBytesUnchecked(ReadOnlySpan<byte> buffer)
        {
            var bytesToCurrent = Math.Min(FreeBytes, buffer.Length);

            buffer.Slice(0, bytesToCurrent).CopyTo(_buffer.AsSpan(Length));

            AddLength(bytesToCurrent);

            var remaining = buffer.Slice(bytesToCurrent);
            if (remaining.IsEmpty == false)
            {
                Expand(remaining.Length);

                remaining.CopyTo(_buffer);
                AddLength(remaining.Length);
            }
        }

        /// <summary>
        /// Writes to write the specified number of bytes from the source stream.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="byteCount"/> is negative.</exception>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        /// <returns>Bytes successfully written from the <paramref name="source" />.</returns>
        public int TryWriteBytes(Stream source, int byteCount)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (byteCount < 0)
                throw new ArgumentOutOfRangeException(nameof(byteCount));
            if (byteCount == 0)
                return 0;

            var bytesRead = 0;
            var bytesToCurrent = Math.Min(FreeBytes, byteCount);
            if (bytesToCurrent > 0)
            {
                bytesRead = source.TryReadAll(_buffer, Length, bytesToCurrent);
                AddLength(bytesRead);

                if (bytesRead != bytesToCurrent)
                    return bytesRead;
            }

            var remaining = byteCount - bytesToCurrent;
            if (remaining > 0)
            {
                Expand(remaining);
                bytesRead = source.TryReadAll(_buffer, 0, remaining);
                AddLength(bytesRead);

                bytesRead += bytesToCurrent;
            }

            return bytesRead;
        }

        /// <summary>
        /// Writes the specified buffer to the builder.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public void WriteBytes(byte[] buffer)
        {
            if (buffer is null)
                throw new ArgumentNullException(nameof(buffer));

            WriteBytes(buffer.AsSpan());
        }

        /// <summary>
        /// Writes the specified buffer to the builder.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Range specified by <paramref name="start"/> and <paramref name="byteCount"/> falls outside of the bounds of the <paramref name="buffer"/>.</exception>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public void WriteBytes(byte[] buffer, int start, int byteCount)
        {
            if (buffer is null)
                throw new ArgumentNullException(nameof(buffer));

            ValidateRange(buffer.Length, start, byteCount, nameof(byteCount));
            WriteBytes(buffer.AsSpan(start, byteCount));
        }

        /// <summary>
        /// Writes the specified buffer to the builder.
        /// </summary>
        /// <param name="buffer"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void WriteBytes(ReadOnlySpan<byte> buffer)
        {
            if (IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            WriteBytesUnchecked(buffer);
        }

        /// <summary>
        /// Writes the specified sequence to the builder.
        /// </summary>
        /// <param name="sequence"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void WriteBytes(in ReadOnlySequence<byte> sequence)
        {
            if (IsHead == false)
                throw new InvalidOperationException("Builder already linked.");

            foreach (var buffer in sequence)
                WriteBytes(buffer.Span);
        }

        /// <summary>
        /// Inserts null bytes up to the given position.
        /// </summary>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public void PadTo(int position)
        {
            WriteBytes(0, position - Count);
        }

        /// <summary>
        /// Returns the number of bits set on the specified <see cref="int"/>.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static int PopCount(int v)
        {
            return PopCount(unchecked((uint)v));
        }

        /// <summary>
        /// Returns the number of bits set on the specified <see cref="uint"/>.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static int PopCount(uint v)
        {
#if NET
            return BitOperations.PopCount(v);
#else
            unchecked
            {
                v -= ((v >> 1) & 0x55555555u);
                v = (v & 0x33333333u) + ((v >> 2) & 0x33333333u);
                return (int)((v + (v >> 4) & 0xF0F0F0Fu) * 0x1010101u) >> 24;
            }
#endif
        }

        /// <summary>
        /// Returns the number of bits set on the specified <see cref="ulong"/>.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static int PopCount(ulong v)
        {
#if NET
            return BitOperations.PopCount(v);
#else
            const ulong Mask01010101 = 0x5555555555555555UL;
            const ulong Mask00110011 = 0x3333333333333333UL;
            const ulong Mask00001111 = 0x0F0F0F0F0F0F0F0FUL;
            const ulong Mask00000001 = 0x0101010101010101UL;
            v -= ((v >> 1) & Mask01010101);
            v = (v & Mask00110011) + ((v >> 2) & Mask00110011);
            return (int)(unchecked(((v + (v >> 4)) & Mask00001111) * Mask00000001) >> 56);
#endif
        }

        /// <summary>
        /// Calculates the alignment based on the current position and alignment.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="alignment"></param>
        /// <returns></returns>
        static uint CalculateAlignment(uint position, uint alignment)
        {
            Debug.Assert(PopCount(alignment) == 1);

            uint result = position & ~(alignment - 1);
            if (result == position)
                return result;

            return result + alignment;
        }

        /// <summary>
        /// Calculates the alignment based on the current position and alignment.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="alignment"></param>
        /// <returns></returns>
        static int CalculateAlignment(int position, int alignment)
        {
            Debug.Assert(position >= 0 && alignment > 0);
            Debug.Assert(PopCount(alignment) == 1);

            int result = position & ~(alignment - 1);
            if (result == position)
                return result;

            return result + alignment;
        }

        /// <summary>
        /// Inserts null bytes up until the alignment is met.
        /// </summary>
        /// <exception cref="InvalidOperationException">Builder is not writable, it has been linked with another one.</exception>
        public void Align(int alignment)
        {
            int position = Count;
            WriteBytes(0, CalculateAlignment(position, alignment) - position);
        }

        /// <summary>
        /// Gets a display string for debugging.
        /// </summary>
        /// <returns></returns>
        internal string GetDebuggerDisplay()
        {
            return IsHead ?
                string.Join("->", GetChunks().Select(chunk => $"[{Display(chunk._buffer, chunk.Length)}]")) :
                $"<{Display(_buffer, Length)}>";
        }

        /// <summary>
        /// Gets a display string for the given byte array for debugging.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static string Display(byte[] bytes, int length)
        {
            const int MaxDisplaySize = 64;

            return (length <= MaxDisplaySize) ?
                BitConverter.ToString(bytes, 0, length) :
                BitConverter.ToString(bytes, 0, MaxDisplaySize / 2) + "-...-" + BitConverter.ToString(bytes, length - MaxDisplaySize / 2, MaxDisplaySize / 2);
        }

        void ClearAndFreeChunk()
        {
            ClearChunk();
            FreeChunk();
        }

    }

}