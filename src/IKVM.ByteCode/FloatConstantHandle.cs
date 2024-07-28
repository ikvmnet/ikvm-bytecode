namespace IKVM.ByteCode
{

    public readonly record struct FloatConstantHandle(ushort Value)
    {

        public static explicit operator FloatConstantHandle(Handle handle)
        {
            return new FloatConstantHandle(handle.Value);
        }

        public static implicit operator Handle(FloatConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator FloatConstantHandle(ConstantHandle handle)
        {
            return new FloatConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(FloatConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
