namespace IKVM.ByteCode
{

    public readonly record struct Utf8ConstantHandle(ushort Index)
    {

        public static explicit operator Utf8ConstantHandle(Handle handle)
        {
            return new Utf8ConstantHandle(handle.Index);
        }

        public static implicit operator Handle(Utf8ConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator Utf8ConstantHandle(ConstantHandle handle)
        {
            return new Utf8ConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(Utf8ConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

    }

}
