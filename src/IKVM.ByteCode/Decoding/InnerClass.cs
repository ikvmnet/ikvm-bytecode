namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents an inner class entry decoded from the <c>InnerClasses</c> attribute.
    /// </summary>
    /// <param name="Inner">The constant pool handle to the inner class.</param>
    /// <param name="Outer">The constant pool handle to the outer class, or the nil handle if the inner class is not a member of a class.</param>
    /// <param name="InnerName">The constant pool handle to the simple name of the inner class, or the nil handle for anonymous classes.</param>
    /// <param name="InnerAccessFlags">The access flags of the inner class as originally declared.</param>
    public readonly record struct InnerClass(ClassConstantHandle Inner, ClassConstantHandle Outer, Utf8ConstantHandle InnerName, AccessFlag InnerAccessFlags)
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
        /// Gets the constant pool handle to the inner class.
        /// </summary>
        public readonly ClassConstantHandle Inner = Inner;

        /// <summary>
        /// Gets the constant pool handle to the outer class, or the nil handle if the inner class is not a member of a class.
        /// </summary>
        public readonly ClassConstantHandle Outer = Outer;

        /// <summary>
        /// Gets the constant pool handle to the simple name of the inner class, or the nil handle for anonymous classes.
        /// </summary>
        public readonly Utf8ConstantHandle InnerName = InnerName;

        /// <summary>
        /// Gets the access flags of the inner class as originally declared.
        /// </summary>
        public readonly AccessFlag InnerAccessFlags = InnerAccessFlags;

    }

}
