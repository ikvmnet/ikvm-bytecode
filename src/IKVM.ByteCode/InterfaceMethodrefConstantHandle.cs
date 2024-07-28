namespace IKVM.ByteCode
{

    public readonly record struct InterfaceMethodrefConstantHandle(ushort Value)
    {

        public static explicit operator InterfaceMethodrefConstantHandle(Handle handle)
        {
            return new InterfaceMethodrefConstantHandle(handle.Value);
        }

        public static implicit operator Handle(InterfaceMethodrefConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator InterfaceMethodrefConstantHandle(ConstantHandle handle)
        {
            return new InterfaceMethodrefConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

        public static explicit operator InterfaceMethodrefConstantHandle(RefConstantHandle handle)
        {
            return new InterfaceMethodrefConstantHandle(handle.Value);
        }

        public static implicit operator RefConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new RefConstantHandle(handle.Value);
        }

    }

}
