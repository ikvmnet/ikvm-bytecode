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

    }

}
