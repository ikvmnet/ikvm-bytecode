namespace IKVM.ByteCode.Writing
{

    public readonly record struct InvokeDynamicConstantHandle(ushort Index)
    {

        public static explicit operator InvokeDynamicConstantHandle(Handle handle)
        {
            return new InvokeDynamicConstantHandle(handle.Index);
        }

        public static implicit operator Handle(InvokeDynamicConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator InvokeDynamicConstantHandle(ConstantHandle handle)
        {
            return new InvokeDynamicConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(InvokeDynamicConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

    }

}
