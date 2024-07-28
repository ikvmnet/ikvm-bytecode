namespace IKVM.ByteCode.Writing
{

    public readonly record struct FieldHandle(ushort Value)
    {

        public static explicit operator FieldHandle(Handle handle)
        {
            return new FieldHandle(handle.Value);
        }

        public static implicit operator Handle(FieldHandle handle)
        {
            return new Handle(handle.Value);
        }

    }

}
