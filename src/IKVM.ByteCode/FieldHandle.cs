namespace IKVM.ByteCode.Writing
{

    public readonly record struct FieldHandle(ushort Index)
    {

        public static explicit operator FieldHandle(Handle handle)
        {
            return new FieldHandle(handle.Index);
        }

        public static implicit operator Handle(FieldHandle handle)
        {
            return new Handle(handle.Index);
        }

    }

}
