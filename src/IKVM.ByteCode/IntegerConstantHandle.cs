namespace IKVM.ByteCode
{

    public readonly record struct IntegerConstantHandle(ushort Value)
    {

        public static explicit operator IntegerConstantHandle(Handle handle)
        {
            return new IntegerConstantHandle(handle.Value);
        }

        public static implicit operator Handle(IntegerConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator IntegerConstantHandle(ConstantHandle handle)
        {
            return new IntegerConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(IntegerConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
