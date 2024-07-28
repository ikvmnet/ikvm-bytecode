namespace IKVM.ByteCode
{

    public readonly record struct MethodrefConstantHandle(ushort Value)
    {

        public static explicit operator MethodrefConstantHandle(Handle handle)
        {
            return new MethodrefConstantHandle(handle.Value);
        }

        public static implicit operator Handle(MethodrefConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator MethodrefConstantHandle(ConstantHandle handle)
        {
            return new MethodrefConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(MethodrefConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

        public static explicit operator MethodrefConstantHandle(RefConstantHandle handle)
        {
            return new MethodrefConstantHandle(handle.Value);
        }

        public static implicit operator RefConstantHandle(MethodrefConstantHandle handle)
        {
            return new RefConstantHandle(handle.Value);
        }

    }

}
