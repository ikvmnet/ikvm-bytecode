namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Fieldref constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct FieldrefConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        public static explicit operator FieldrefConstantHandle(ConstantHandle handle)
        {
            return new FieldrefConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="FieldrefConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(FieldrefConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Fieldref, handle.Slot);
        }

        /// <summary>
        /// Explicitly converts a <see cref="RefConstantHandle"/> to a <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        public static explicit operator FieldrefConstantHandle(RefConstantHandle handle)
        {
            return new FieldrefConstantHandle(handle.Index);
        }

        /// <summary>
        /// Implicitly converts a <see cref="FieldrefConstantHandle"/> to a <see cref="RefConstantHandle"/>.
        /// </summary>
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
