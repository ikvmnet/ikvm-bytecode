namespace IKVM.ByteCode
{

    public readonly record struct RefConstantHandle(ConstantKind Kind, ushort Index)
    {

        public static explicit operator RefConstantHandle(ConstantHandle handle)
        {
            return new RefConstantHandle(handle.Kind, handle.Index);
        }

        public static implicit operator ConstantHandle(RefConstantHandle handle)
        {
            return new ConstantHandle(handle.Kind, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly RefConstantHandle Nil = new(ConstantKind.Unknown, 0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

        /// <summary>
        /// Gets whether or not this does not represent the nil instance.
        /// </summary>
        public readonly bool IsNotNil => !IsNil;

    }

}
