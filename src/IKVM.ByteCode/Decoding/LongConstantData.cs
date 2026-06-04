using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the data of a <c>CONSTANT_Long_info</c> entry decoded from the constant pool.
    /// </summary>
    /// <param name="Value">The 64-bit integer value.</param>
    public readonly record struct LongConstantData(long Value)
    {

        /// <summary>
        /// Measures a constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <param name="skip">The number of bytes to skip.</param>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size, out int skip)
        {
            skip = 1;

            size += ClassFormatReader.U4 + ClassFormatReader.U4;
            if (reader.TryAdvance(ClassFormatReader.U4 + ClassFormatReader.U4) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Long constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="data">The raw data buffer.</param>
        /// <param name="skip">The number of bytes to skip.</param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 1;

            if (reader.TryReadMany(ClassFormatReader.U4 + ClassFormatReader.U4, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Long constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="constant">The decoded constant.</param>
        public static bool TryRead(ref ClassFormatReader reader, out LongConstantData constant)
        {
            constant = default;

            if (reader.TryReadU4(out uint a) == false)
                return false;
            if (reader.TryReadU4(out uint b) == false)
                return false;

            constant = new LongConstantData((long)(((ulong)a << 32) | b));
            return true;
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        public readonly long Value = Value;

    }

}
