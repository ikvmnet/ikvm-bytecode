namespace IKVM.ByteCode
{

    public readonly record struct FloatConstantHandle(ushort Index)
    {

        public static explicit operator FloatConstantHandle(Handle handle)
        {
            return new FloatConstantHandle(handle.Index);
        }

        public static implicit operator Handle(FloatConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator FloatConstantHandle(ConstantHandle handle)
        {
            return new FloatConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(FloatConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly FloatConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
