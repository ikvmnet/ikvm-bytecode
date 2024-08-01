namespace IKVM.ByteCode
{

    public readonly record struct FieldrefConstantHandle(ushort Index)
    {

        public static explicit operator FieldrefConstantHandle(Handle handle)
        {
            return new FieldrefConstantHandle(handle.Index);
        }

        public static implicit operator Handle(FieldrefConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator FieldrefConstantHandle(ConstantHandle handle)
        {
            return new FieldrefConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(FieldrefConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
        }

        public static explicit operator FieldrefConstantHandle(RefConstantHandle handle)
        {
            return new FieldrefConstantHandle(handle.Index);
        }

        public static implicit operator RefConstantHandle(FieldrefConstantHandle handle)
        {
            return new RefConstantHandle(handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly FieldrefConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
