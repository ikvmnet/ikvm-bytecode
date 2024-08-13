namespace IKVM.ByteCode.Decoding
{

    public readonly record struct MethodParameter(Utf8ConstantHandle Name, AccessFlag AccessFlags)
    {

        public readonly Utf8ConstantHandle Name = Name;
        public readonly AccessFlag AccessFlags = AccessFlags;
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
