namespace IKVM.ByteCode
{

    public readonly record struct RefConstantHandle(ushort Index)
    {

        public static explicit operator RefConstantHandle(Handle handle)
        {
            return new RefConstantHandle(handle.Index);
        }

        public static implicit operator Handle(RefConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator RefConstantHandle(ConstantHandle handle)
        {
            return new RefConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(RefConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

    }

}
