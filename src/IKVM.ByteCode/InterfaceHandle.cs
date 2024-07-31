namespace IKVM.ByteCode
{

    public readonly record struct InterfaceHandle(ushort Index)
    {

        public static explicit operator InterfaceHandle(Handle handle)
        {
            return new InterfaceHandle(handle.Index);
        }

        public static implicit operator Handle(InterfaceHandle handle)
        {
            return new Handle(handle.Index);
        }

    }

}
