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

    }

}
