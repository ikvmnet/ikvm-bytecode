using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a String constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct StringConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.String"/>.</exception>
        public static explicit operator StringConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.String and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to String.");

            return new StringConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="StringConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(StringConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.String, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly StringConstantHandle Nil = new(0);

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
