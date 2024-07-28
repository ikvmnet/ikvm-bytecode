namespace IKVM.ByteCode
{

    public readonly record struct MethodHandle(ushort Value)
    {

        public static explicit operator MethodHandle(Handle handle)
        {
            return new MethodHandle(handle.Value);
        }

        public static implicit operator Handle(MethodHandle handle)
        {
            return new Handle(handle.Value);
        }

    }

}
