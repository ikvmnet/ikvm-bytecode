namespace IKVM.ByteCode
{

    public readonly record struct PackageConstantHandle(ushort Index)
    {

        public static explicit operator PackageConstantHandle(Handle handle)
        {
            return new PackageConstantHandle(handle.Index);
        }

        public static implicit operator Handle(PackageConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator PackageConstantHandle(ConstantHandle handle)
        {
            return new PackageConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(PackageConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

    }

}
