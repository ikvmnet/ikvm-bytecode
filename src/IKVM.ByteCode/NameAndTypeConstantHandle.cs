namespace IKVM.ByteCode
{

    public readonly record struct NameAndTypeConstantHandle(ushort Index)
    {

        public static explicit operator NameAndTypeConstantHandle(Handle handle)
        {
            return new NameAndTypeConstantHandle(handle.Index);
        }

        public static implicit operator Handle(NameAndTypeConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator NameAndTypeConstantHandle(ConstantHandle handle)
        {
            return new NameAndTypeConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(NameAndTypeConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly NameAndTypeConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
