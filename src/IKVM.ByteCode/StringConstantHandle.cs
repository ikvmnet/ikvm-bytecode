namespace IKVM.ByteCode
{

    public readonly record struct StringConstantHandle(ushort Index)
    {

        public static explicit operator StringConstantHandle(Handle handle)
        {
            return new StringConstantHandle(handle.Index);
        }

        public static implicit operator Handle(StringConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator StringConstantHandle(ConstantHandle handle)
        {
            return new StringConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(StringConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly StringConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
