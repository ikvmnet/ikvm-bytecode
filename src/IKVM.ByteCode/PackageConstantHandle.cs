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

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly PackageConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
