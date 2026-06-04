using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Provides common methods to read through memory of a Class file.
    /// </summary>
    public ref struct ClassFormatReader
    {

        public const int U1 = 1;
        public const int U2 = 2;
        public const int U4 = 4;

        SequenceReader<byte> _reader;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="buffer">The buffer containing class file data.</param>
        public ClassFormatReader(ReadOnlyMemory<byte> buffer) :
            this(new ReadOnlySequence<byte>(buffer))
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="sequence">The buffer sequence containing class file data.</param>
        public ClassFormatReader(ReadOnlySequence<byte> sequence)
        {
            _reader = new SequenceReader<byte>(sequence);
        }

        /// <summary>
        /// Gets the count of bytes in the reader.
        /// </summary>
        public readonly long Length => _reader.Length;

        /// <summary>
        /// Gets the current position in the reader.
        /// </summary>
        public readonly SequencePosition Position => _reader.Position;

        /// <summary>
        /// Gets the amount of data that has been consumed by this reader.
        /// </summary>
        public readonly long Consumed => _reader.Consumed;

        /// <summary>
        /// Gets the number of remaining bytes in the reader.
        /// </summary>
        public readonly long Remaining => _reader.Remaining;

        /// <summary>
        /// Moves the reader back the specified number of bytes.
        /// </summary>
        /// <param name="count">The number of items.</param>
        public void Rewind(long count)
        {
            _reader.Rewind(count);
        }

        /// <summary>
        /// Moves the reader forward the specified number of bytes.
        /// </summary>
        /// <param name="count">The number of items.</param>
        public bool TryAdvance(long count)
        {
            return _reader.TryAdvance(count);
        }

        /// <summary>
        /// Attempts to read a value defined as a 'u1'.
        /// </summary>
        /// <param name="u1">The decoded unsigned 8-bit value.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public bool TryReadU1(out byte u1)
        {
            return _reader.TryRead(out u1);
        }

        /// <summary>
        /// Attempts to read a value defined as a 'u2'.
        /// </summary>
        /// <param name="u2">The decoded unsigned 16-bit value.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public bool TryReadU2(out ushort u2)
        {
            return _reader.TryReadBigEndian(out u2);
        }

        /// <summary>
        /// Attempts to read a value defined as a 'u4'.
        /// </summary>
        /// <param name="u4">The decoded unsigned 32-bit value.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public bool TryReadU4(out uint u4)
        {
            return _reader.TryReadBigEndian(out u4);
        }

        /// <summary>
        /// Attempts to read the exact given number of bytes.
        /// </summary>
        /// <param name="count">The number of items.</param>
        /// <param name="sequence">The buffer sequence containing class file data.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public bool TryReadMany(uint count, out ReadOnlySequence<byte> sequence)
        {
            return _reader.TryReadExact(count, out sequence);
        }

        /// <summary>
        /// Attempts to read the exact given number of bytes.
        /// </summary>
        /// <param name="count">The number of items.</param>
        /// <param name="sequence">The buffer sequence containing class file data.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public bool TryReadMany(long count, out ReadOnlySequence<byte> sequence)
        {
            return _reader.TryReadExact(count, out sequence);
        }

        /// <summary>
        /// Attempts to copy available data at the current position to the destination.
        /// </summary>
        /// <param name="destination">The span to copy bytes into.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public bool TryCopyTo(Span<byte> destination)
        {
            return _reader.TryCopyTo(destination);
        }

    }

}
