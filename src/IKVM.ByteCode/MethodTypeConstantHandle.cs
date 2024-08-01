namespace IKVM.ByteCode
{

    public readonly record struct MethodTypeConstantHandle(ushort Index)
    {

        public static explicit operator MethodTypeConstantHandle(Handle handle)
        {
            return new MethodTypeConstantHandle(handle.Index);
        }

        public static implicit operator Handle(MethodTypeConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator MethodTypeConstantHandle(ConstantHandle handle)
        {
            return new MethodTypeConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(MethodTypeConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly MethodTypeConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
