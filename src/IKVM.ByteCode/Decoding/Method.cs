namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a method decoded from a class file.
    /// </summary>
    /// <param name="AccessFlags">The access flags of the method.</param>
    /// <param name="Name">The constant pool handle to the method name.</param>
    /// <param name="Descriptor">The constant pool handle to the method descriptor.</param>
    /// <param name="Attributes">The attribute table of the method.</param>
    public readonly record struct Method(AccessFlag AccessFlags, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeTable Attributes)
    {

        /// <summary>
        /// Parses a method.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
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
        /// Parses a method.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
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
            if (AttributeTable.TryRead(ref reader, out var attributes) == false)
                return false;

            method = new Method((AccessFlag)accessFlags, new(nameIndex), new(descriptorIndex), attributes!);
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
        /// Gets the access flags of the method.
        /// </summary>
        public readonly AccessFlag AccessFlags = AccessFlags;

        /// <summary>
        /// Gets the constant pool handle to the method name.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

        /// <summary>
        /// Gets the constant pool handle to the method descriptor.
        /// </summary>
        public readonly Utf8ConstantHandle Descriptor = Descriptor;

        /// <summary>
        /// Gets the attribute table of the method.
        /// </summary>
        public readonly AttributeTable Attributes = Attributes;

    }

}
