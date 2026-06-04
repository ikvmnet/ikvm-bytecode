namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a method parameter entry decoded from the <c>MethodParameters</c> attribute.
    /// </summary>
    /// <param name="Name">The constant pool handle to the parameter name, or the nil handle if the parameter has no name.</param>
    /// <param name="AccessFlags">The access flags of the parameter.</param>
    public readonly record struct MethodParameter(Utf8ConstantHandle Name, AccessFlag AccessFlags)
    {

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
        /// Gets the constant pool handle to the parameter name, or the nil handle if the parameter has no name.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

        /// <summary>
        /// Gets the access flags of the parameter.
        /// </summary>
        public readonly AccessFlag AccessFlags = AccessFlags;

    }

}
