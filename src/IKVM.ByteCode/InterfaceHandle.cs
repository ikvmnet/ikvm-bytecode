namespace IKVM.ByteCode
{

    public readonly record struct InterfaceHandle(ushort Value)
    {

        public static explicit operator InterfaceHandle(Handle handle)
        {
            return new InterfaceHandle(handle.Value);
        }

        public static implicit operator Handle(InterfaceHandle handle)
        {
            return new Handle(handle.Value);
        }

    }

}
