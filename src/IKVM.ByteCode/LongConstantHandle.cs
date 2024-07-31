namespace IKVM.ByteCode
{

    public readonly record struct LongConstantHandle(ushort Index)
    {

        public static explicit operator LongConstantHandle(Handle handle)
        {
            return new LongConstantHandle(handle.Index);
        }

        public static implicit operator Handle(LongConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator LongConstantHandle(ConstantHandle handle)
        {
            return new LongConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(LongConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

    }

}
