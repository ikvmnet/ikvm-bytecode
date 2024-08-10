namespace IKVM.ByteCode
{

    public readonly record struct FieldrefConstantHandle(ushort Slot)
    {

        public static explicit operator FieldrefConstantHandle(ConstantHandle handle)
        {
            return new FieldrefConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(FieldrefConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Fieldref, handle.Slot);
        }

        public static explicit operator FieldrefConstantHandle(RefConstantHandle handle)
        {
            return new FieldrefConstantHandle(handle.Index);
        }

        public static implicit operator RefConstantHandle(FieldrefConstantHandle handle)
        {
            return new RefConstantHandle(ConstantKind.Fieldref, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly FieldrefConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Slot == 0;

        /// <summary>
        /// Gets whether or not this does not represent the nil instance.
        /// </summary>
        public readonly bool IsNotNil => !IsNil;

    }

}
