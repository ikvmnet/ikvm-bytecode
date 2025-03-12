using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Double constant.
    /// </summary>
    /// <param name="Slot"></param>
    public readonly record struct DoubleConstantHandle(ushort Slot)
    {

        public static explicit operator DoubleConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Double and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Double.");

            return new DoubleConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(DoubleConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Double, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly DoubleConstantHandle Nil = new(0);

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
