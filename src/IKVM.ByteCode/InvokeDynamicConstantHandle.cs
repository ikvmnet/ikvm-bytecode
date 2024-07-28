namespace IKVM.ByteCode.Writing
{

    public readonly record struct InvokeDynamicConstantHandle(ushort Value)
    {

        public static explicit operator InvokeDynamicConstantHandle(Handle handle)
        {
            return new InvokeDynamicConstantHandle(handle.Value);
        }

        public static implicit operator Handle(InvokeDynamicConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator InvokeDynamicConstantHandle(ConstantHandle handle)
        {
            return new InvokeDynamicConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(InvokeDynamicConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
