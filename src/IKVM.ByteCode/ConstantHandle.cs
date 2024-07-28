namespace IKVM.ByteCode
{

    public readonly record struct ConstantHandle(ushort Value)
    {

        public static explicit operator ConstantHandle(Handle handle)
        {
            return new ConstantHandle(handle.Value);
        }

        public static implicit operator Handle(ConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

    }

}
