using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct DoubleConstantData(double Value)
    {

        /// <summary>
        /// Parses a Double constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <param name="skip"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 1;

            if (reader.TryReadMany(ClassFormatReader.U4 + ClassFormatReader.U4, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Double constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out DoubleConstantData constant)
        {
            constant = default;

            if (reader.TryReadU4(out uint a) == false)
                return false;
            if (reader.TryReadU4(out uint b) == false)
                return false;

            constant = new DoubleConstantData(RawBitConverter.UInt64BitsToDouble(((ulong)a << 32) | b));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
