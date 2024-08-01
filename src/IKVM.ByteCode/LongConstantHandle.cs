namespace IKVM.ByteCode
{

    public readonly record struct LongConstantHandle(ushort Index)
    {

        public static explicit operator LongConstantHandle(Handle handle)
        {
            return new LongConstantHandle(handle.Index);
        }

        public static implicit operator Handle(LongConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator LongConstantHandle(ConstantHandle handle)
        {
            return new LongConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(LongConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly LongConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
