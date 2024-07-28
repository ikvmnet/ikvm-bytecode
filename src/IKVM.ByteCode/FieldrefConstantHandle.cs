namespace IKVM.ByteCode
{

    public readonly record struct FieldrefConstantHandle(ushort Value)
    {

        public static explicit operator FieldrefConstantHandle(Handle handle)
        {
            return new FieldrefConstantHandle(handle.Value);
        }

        public static implicit operator Handle(FieldrefConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator FieldrefConstantHandle(ConstantHandle handle)
        {
            return new FieldrefConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(FieldrefConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

        public static explicit operator FieldrefConstantHandle(RefConstantHandle handle)
        {
            return new FieldrefConstantHandle(handle.Value);
        }

        public static implicit operator RefConstantHandle(FieldrefConstantHandle handle)
        {
            return new RefConstantHandle(handle.Value);
        }

    }

}
