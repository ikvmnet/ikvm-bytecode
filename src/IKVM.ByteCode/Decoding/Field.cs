namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a field decoded from a class file.
    /// </summary>
    /// <param name="AccessFlags">The access flags of the field.</param>
    /// <param name="Name">The constant pool handle to the field name.</param>
    /// <param name="Descriptor">The constant pool handle to the field descriptor.</param>
    /// <param name="Attributes">The attribute table of the field.</param>
    public readonly record struct Field(AccessFlag AccessFlags, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeTable Attributes)
    {

        /// <summary>
        /// Parses an interface.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            if (AttributeTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read a Field starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="field"></param>
        public static bool TryRead(ref ClassFormatReader reader, out Field field)
        {
            field = default;

            if (reader.TryReadU2(out ushort accessFlags) == false)
                return false;
            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort descriptorIndex) == false)
                return false;
            if (AttributeTable.TryRead(ref reader, out var attributes) == false)
                return false;

            field = new Field((AccessFlag)accessFlags, new(nameIndex), new(descriptorIndex), attributes);
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
        /// Gets the access flags of the field.
        /// </summary>
        public readonly AccessFlag AccessFlags = AccessFlags;

        /// <summary>
        /// Gets the constant pool handle to the field name.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

        /// <summary>
        /// Gets the constant pool handle to the field descriptor.
        /// </summary>
        public readonly Utf8ConstantHandle Descriptor = Descriptor;

        /// <summary>
        /// Gets the attribute table of the field.
        /// </summary>
        public readonly AttributeTable Attributes = Attributes;

    }

}
