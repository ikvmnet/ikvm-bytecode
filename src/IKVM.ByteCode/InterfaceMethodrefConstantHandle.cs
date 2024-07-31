namespace IKVM.ByteCode
{

    public readonly record struct InterfaceMethodrefConstantHandle(ushort Index)
    {

        public static explicit operator InterfaceMethodrefConstantHandle(Handle handle)
        {
            return new InterfaceMethodrefConstantHandle(handle.Index);
        }

        public static implicit operator Handle(InterfaceMethodrefConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator InterfaceMethodrefConstantHandle(ConstantHandle handle)
        {
            return new InterfaceMethodrefConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        public static explicit operator InterfaceMethodrefConstantHandle(RefConstantHandle handle)
        {
            return new InterfaceMethodrefConstantHandle(handle.Index);
        }

        public static implicit operator RefConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new RefConstantHandle(handle.Index);
        }

    }

}
