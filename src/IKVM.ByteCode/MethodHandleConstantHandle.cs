namespace IKVM.ByteCode
{

    public readonly record struct MethodHandleConstantHandle(ushort Index)
    {

        public static explicit operator MethodHandleConstantHandle(Handle handle)
        {
            return new MethodHandleConstantHandle(handle.Index);
        }

        public static implicit operator Handle(MethodHandleConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator MethodHandleConstantHandle(ConstantHandle handle)
        {
            return new MethodHandleConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(MethodHandleConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly MethodHandleConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
