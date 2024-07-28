namespace IKVM.ByteCode
{

    public readonly record struct MethodHandleConstantHandle(ushort Value)
    {

        public static explicit operator MethodHandleConstantHandle(Handle handle)
        {
            return new MethodHandleConstantHandle(handle.Value);
        }

        public static implicit operator Handle(MethodHandleConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator MethodHandleConstantHandle(ConstantHandle handle)
        {
            return new MethodHandleConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(MethodHandleConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
