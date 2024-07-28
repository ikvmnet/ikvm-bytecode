namespace IKVM.ByteCode
{

    public readonly record struct DynamicConstantHandle(ushort Value)
    {

        public static explicit operator DynamicConstantHandle(Handle handle)
        {
            return new DynamicConstantHandle(handle.Value);
        }

        public static implicit operator Handle(DynamicConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator DynamicConstantHandle(ConstantHandle handle)
        {
            return new DynamicConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(DynamicConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
