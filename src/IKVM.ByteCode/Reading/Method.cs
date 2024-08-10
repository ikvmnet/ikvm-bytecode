namespace IKVM.ByteCode.Reading
{

    public readonly record struct Method(AccessFlag AccessFlags, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeTable Attributes)
    {

        /// <summary>
        /// Parses a method.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="method"></param>
        public static bool TryRead(ref ClassFormatReader reader, out Method method)
        {
            method = default;

            if (reader.TryReadU2(out ushort accessFlags) == false)
                return false;
            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort descriptorIndex) == false)
                return false;
            if (ClassFile.TryReadAttributeTable(ref reader, out var attributes) == false)
                return false;

            method = new Method((AccessFlag)accessFlags, new(nameIndex), new(descriptorIndex), attributes!);
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
