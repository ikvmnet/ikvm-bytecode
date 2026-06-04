using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the data of a <c>CONSTANT_MethodType_info</c> entry decoded from the constant pool.
    /// </summary>
    /// <param name="Descriptor">The constant pool handle to the UTF-8 method descriptor.</param>
    public readonly record struct MethodTypeConstantData(Utf8ConstantHandle Descriptor)
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

            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a MethodType constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="data">The raw data buffer.</param>
        /// <param name="skip">The number of bytes to skip.</param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a MethodType constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="constant">The decoded constant.</param>
        public static bool TryRead(ref ClassFormatReader reader, out MethodTypeConstantData constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort descriptorIndex) == false)
                return false;

            constant = new MethodTypeConstantData(new Utf8ConstantHandle(descriptorIndex));
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
        /// Gets the constant pool handle to the UTF-8 method descriptor.
        /// </summary>
        public readonly Utf8ConstantHandle Descriptor = Descriptor;

    }

}
