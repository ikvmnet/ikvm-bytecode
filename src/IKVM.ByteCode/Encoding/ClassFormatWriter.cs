﻿using System;
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

        Span<byte> span;
        Span<byte> next;
        long size = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="span"></param>
        public ClassFormatWriter(Span<byte> span)
        {
            this.span = next = span;
        }

        /// <summary>
        /// Gets the span being written to.
        /// </summary>
        public readonly Span<byte> Span => span;

        /// <summary>
        /// Gets the total number of written bytes.
        /// </summary>
        public long Size => size;

        /// <summary>
        /// Writes a value defined as a 'u1' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryWriteU1(byte value)
        {
            if (next.Length < sizeof(byte))
                return false;

            next[0] = value;
            next = next.Slice(sizeof(byte));
            size += sizeof(byte);
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
            if (next.Length < sizeof(ushort))
                return false;

            BinaryPrimitives.WriteUInt16BigEndian(next, value);
            next = next.Slice(sizeof(ushort));
            size += sizeof(ushort);
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
            if (next.Length < sizeof(uint))
                return false;

            BinaryPrimitives.WriteUInt32BigEndian(next, value);
            next = next.Slice(sizeof(uint));
            size += sizeof(uint);
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