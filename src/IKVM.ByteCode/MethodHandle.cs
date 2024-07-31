namespace IKVM.ByteCode
{

    public readonly record struct MethodHandle(ushort Index)
    {

        public static explicit operator MethodHandle(Handle handle)
        {
            return new MethodHandle(handle.Index);
        }

        public static implicit operator Handle(MethodHandle handle)
        {
            return new Handle(handle.Index);
        }

    }

}
