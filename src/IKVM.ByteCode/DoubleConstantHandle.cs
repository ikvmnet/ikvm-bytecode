namespace IKVM.ByteCode
{

    public readonly record struct DoubleConstantHandle(ushort Value)
    {

        public static explicit operator DoubleConstantHandle(Handle handle)
        {
            return new DoubleConstantHandle(handle.Value);
        }

        public static implicit operator Handle(DoubleConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator DoubleConstantHandle(ConstantHandle handle)
        {
            return new DoubleConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(DoubleConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
