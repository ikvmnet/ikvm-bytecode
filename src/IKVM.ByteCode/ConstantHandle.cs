namespace IKVM.ByteCode
{

    public readonly record struct ConstantHandle(ushort Index)
    {

        public static explicit operator ConstantHandle(Handle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        public static implicit operator Handle(ConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly ConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
