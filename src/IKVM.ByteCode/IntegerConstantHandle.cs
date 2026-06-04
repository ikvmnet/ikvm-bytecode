using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Integer constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct IntegerConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to an <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.Integer"/>.</exception>
        public static explicit operator IntegerConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Integer and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Integer.");

            return new IntegerConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts an <see cref="IntegerConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(IntegerConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Integer, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly IntegerConstantHandle Nil = new(0);

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
