using System;
using System.Buffers.Binary;

namespace IKVM.ByteCode.Encoding
{

    /// <summary>
    /// Provides a forward-only writer of big-endian values.
    /// </summary>
    public ref struct ClassFormatWriter
    {

        public const int U1 = 1;
        public const int U2 = 2;
        public const int U4 = 4;

        Span<byte> _span;
        Span<byte> _next;
        long _size = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="span"></param>
        public ClassFormatWriter(Span<byte> span)
        {
            _span = _next = span;
        }

        /// <summary>
        /// Gets the span being written to.
        /// </summary>
        public readonly Span<byte> Span => _span;

        /// <summary>
        /// Gets the total number of written bytes.
        /// </summary>
        public readonly long Size => _size;

        /// <summary>
        /// Writes a value defined as a 'u1' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryWriteU1(byte value)
        {
            if (_next.Length < U1)
                return false;

            _next[0] = value;
            _next = _next.Slice(U1);
            _size += U1;
            return true;
        }

        /// <summary>
        /// Writes a value defined as a 'u1' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void WriteU1(byte value)
        {
            if (TryWriteU1(value) == false)
                throw new InvalidOperationException("Failed to write.");
        }

        /// <summary>
        /// Writes a value defined as a 'u2' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryWriteU2(ushort value)
        {
            if (_next.Length < U2)
                return false;

            BinaryPrimitives.WriteUInt16BigEndian(_next, value);
            _next = _next.Slice(U2);
            _size += U2;
            return true;
        }

        /// <summary>
        /// Writes a value defined as a 'u2' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void WriteU2(ushort value)
        {
            if (TryWriteU2(value) == false)
                throw new InvalidOperationException("Failed to write.");
        }

        /// <summary>
        /// Writes a value defined as a 'u4' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryWriteU4(uint value)
        {
            if (_next.Length < U4)
                return false;

            BinaryPrimitives.WriteUInt32BigEndian(_next, value);
            _next = _next.Slice(U4);
            _size += U4;
            return true;
        }

        /// <summary>
        /// Writes a value defined as a 'u4' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void WriteU4(uint value)
        {
            if (TryWriteU4(value) == false)
                throw new InvalidOperationException("Failed to write.");
        }

    }

}
