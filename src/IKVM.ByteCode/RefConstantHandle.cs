namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Ref constant, including Fieldref, Methodref and InterfaceMethodref.
    /// </summary>
    /// <param name="Kind">The specific constant kind: <see cref="ConstantKind.Fieldref"/>, <see cref="ConstantKind.Methodref"/>, or <see cref="ConstantKind.InterfaceMethodref"/>.</param>
    /// <param name="Index">The constant pool slot index.</param>
    public readonly record struct RefConstantHandle(ConstantKind Kind, ushort Index)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="RefConstantHandle"/>.
        /// </summary>
        public static explicit operator RefConstantHandle(ConstantHandle handle)
        {
            return new RefConstantHandle(handle.Kind, handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="RefConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(RefConstantHandle handle)
        {
            return new ConstantHandle(handle.Kind, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly RefConstantHandle Nil = new(ConstantKind.Unknown, 0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

        /// <summary>
        /// Gets whether or not this does not represent the nil instance.
        /// </summary>
        public readonly bool IsNotNil => !IsNil;

    }

}
