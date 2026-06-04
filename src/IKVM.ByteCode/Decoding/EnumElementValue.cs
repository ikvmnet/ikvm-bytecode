using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents an enum element value decoded from a class file annotation.
    /// </summary>
    /// <param name="TypeName">The constant pool handle to the UTF-8 binary name of the enum type.</param>
    /// <param name="ConstantName">The constant pool handle to the UTF-8 simple name of the enum constant.</param>
    public readonly record struct EnumElementValue(Utf8ConstantHandle TypeName, Utf8ConstantHandle ConstantName)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            if (reader.TryReadMany(ClassFormatReader.U2 + ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out EnumElementValue value)
        {
            value = default;

            if (reader.TryReadU2(out ushort typeNameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort constantNameIndex) == false)
                return false;

            value = new EnumElementValue(new(typeNameIndex), new(constantNameIndex));
            return true;
        }

        /// <summary>
        /// Gets the constant pool handle to the UTF-8 binary name of the enum type.
        /// </summary>
        public readonly Utf8ConstantHandle TypeName = TypeName;

        /// <summary>
        /// Gets the constant pool handle to the UTF-8 simple name of the enum constant.
        /// </summary>
        public readonly Utf8ConstantHandle ConstantName = ConstantName;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
