namespace IKVM.ByteCode
{

    public readonly record struct MethodrefConstantHandle(ushort Index)
    {

        public static explicit operator MethodrefConstantHandle(Handle handle)
        {
            return new MethodrefConstantHandle(handle.Index);
        }

        public static implicit operator Handle(MethodrefConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator MethodrefConstantHandle(ConstantHandle handle)
        {
            return new MethodrefConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(MethodrefConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        public static explicit operator MethodrefConstantHandle(RefConstantHandle handle)
        {
            return new MethodrefConstantHandle(handle.Index);
        }

        public static implicit operator RefConstantHandle(MethodrefConstantHandle handle)
        {
            return new RefConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly MethodrefConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
