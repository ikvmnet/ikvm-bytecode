namespace IKVM.ByteCode
{

    public readonly record struct MethodTypeConstantHandle(ushort Value)
    {

        public static explicit operator MethodTypeConstantHandle(Handle handle)
        {
            return new MethodTypeConstantHandle(handle.Value);
        }

        public static implicit operator Handle(MethodTypeConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator MethodTypeConstantHandle(ConstantHandle handle)
        {
            return new MethodTypeConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(MethodTypeConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
