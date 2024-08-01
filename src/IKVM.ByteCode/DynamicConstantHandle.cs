namespace IKVM.ByteCode
{

    public readonly record struct DynamicConstantHandle(ushort Index)
    {

        public static explicit operator DynamicConstantHandle(Handle handle)
        {
            return new DynamicConstantHandle(handle.Index);
        }

        public static implicit operator Handle(DynamicConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator DynamicConstantHandle(ConstantHandle handle)
        {
            return new DynamicConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(DynamicConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly DynamicConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
