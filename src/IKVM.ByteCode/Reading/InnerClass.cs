namespace IKVM.ByteCode.Reading
{

    public readonly record struct InnerClass(ClassConstantHandle Inner, ClassConstantHandle Outer, Utf8ConstantHandle InnerName, AccessFlag InnerAccessFlags)
    {

        public readonly ClassConstantHandle Inner = Inner;
        public readonly ClassConstantHandle Outer = Outer;
        public readonly Utf8ConstantHandle InnerName = InnerName;
        public readonly AccessFlag InnerAccessFlags = InnerAccessFlags;
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
