namespace IKVM.ByteCode.Reading
{

    public readonly record struct Field(AccessFlag AccessFlags, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeTable Attributes)
    {

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
            if (ClassFile.TryReadAttributeTable(ref reader, out var attributes) == false)
                return false;

            field = new Field((AccessFlag)accessFlags, new(nameIndex), new(descriptorIndex), attributes);
            return true;
        }

        public readonly AccessFlag AccessFlags = AccessFlags;
        public readonly Utf8ConstantHandle Name = Name;
        public readonly Utf8ConstantHandle Descriptor = Descriptor;
        public readonly AttributeTable Attributes = Attributes;
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
