namespace IKVM.ByteCode.Writing
{

    public readonly record struct AttributeHandle(ushort Value)
    {

        public static explicit operator AttributeHandle(Handle handle)
        {
            return new AttributeHandle(handle.Value);
        }

        public static implicit operator Handle(AttributeHandle handle)
        {
            return new Handle(handle.Value);
        }

    }

}
