namespace IKVM.ByteCode
{

    public readonly record struct IntegerConstantHandle(ushort Index)
    {

        public static explicit operator IntegerConstantHandle(Handle handle)
        {
            return new IntegerConstantHandle(handle.Index);
        }

        public static implicit operator Handle(IntegerConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator IntegerConstantHandle(ConstantHandle handle)
        {
            return new IntegerConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(IntegerConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly IntegerConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
