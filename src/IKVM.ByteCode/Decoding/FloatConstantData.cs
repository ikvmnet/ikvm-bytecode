using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the data of a <c>CONSTANT_Float_info</c> entry decoded from the constant pool.
    /// </summary>
    /// <param name="Value">The single-precision floating-point value.</param>
    public readonly record struct FloatConstantData(float Value)
    {

        /// <summary>
        /// Measures a constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <param name="skip">The number of bytes to skip.</param>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size, out int skip)
        {
            skip = 0;

            size += ClassFormatReader.U4;
            if (reader.TryAdvance(ClassFormatReader.U4) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Float constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="data">The raw data buffer.</param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U4, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Float constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="constant">The decoded constant.</param>
        public static bool TryRead( ref ClassFormatReader reader, out FloatConstantData constant)
        {
            constant = default;

            if (reader.TryReadU4(out uint value) == false)
                return false;

            constant = new FloatConstantData(RawBitConverter.UInt32BitsToSingle(value));
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

        /// <summary>
        /// Gets the single-precision floating-point value.
        /// </summary>
        public readonly float Value = Value;

    }

}
