namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a constant.
    /// </summary>
    /// <param name="Kind"></param>
    /// <param name="Slot"></param>
    public readonly record struct ConstantHandle(ConstantKind Kind, ushort Slot)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly ConstantHandle Nil = new(ConstantKind.Unknown, 0);

        public static explicit operator byte(ConstantHandle handle) => checked((byte)handle.Slot);

        public static explicit operator ushort(ConstantHandle handle) => handle.Slot;

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
