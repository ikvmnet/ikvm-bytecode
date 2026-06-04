using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Utf8 constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct Utf8ConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.Utf8"/>.</exception>
        public static explicit operator Utf8ConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Utf8 and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Utf8.");

            return new Utf8ConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Utf8ConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(Utf8ConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Utf8, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly Utf8ConstantHandle Nil = new(0);

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
