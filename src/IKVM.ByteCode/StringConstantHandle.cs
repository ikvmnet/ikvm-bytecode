namespace IKVM.ByteCode
{

    public readonly record struct StringConstantHandle(ushort Value)
    {

        public static explicit operator StringConstantHandle(Handle handle)
        {
            return new StringConstantHandle(handle.Value);
        }

        public static implicit operator Handle(StringConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator StringConstantHandle(ConstantHandle handle)
        {
            return new StringConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(StringConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
