namespace IKVM.ByteCode
{

    public readonly record struct LongConstantHandle(ushort Value)
    {

        public static explicit operator LongConstantHandle(Handle handle)
        {
            return new LongConstantHandle(handle.Value);
        }

        public static implicit operator Handle(LongConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator LongConstantHandle(ConstantHandle handle)
        {
            return new LongConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(LongConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
