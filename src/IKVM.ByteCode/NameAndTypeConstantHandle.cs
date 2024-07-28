namespace IKVM.ByteCode
{

    public readonly record struct NameAndTypeConstantHandle(ushort Value)
    {

        public static explicit operator NameAndTypeConstantHandle(Handle handle)
        {
            return new NameAndTypeConstantHandle(handle.Value);
        }

        public static implicit operator Handle(NameAndTypeConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator NameAndTypeConstantHandle(ConstantHandle handle)
        {
            return new NameAndTypeConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(NameAndTypeConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
