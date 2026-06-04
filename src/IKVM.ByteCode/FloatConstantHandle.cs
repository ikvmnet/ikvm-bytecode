using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Float constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct FloatConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.Float"/>.</exception>
        public static explicit operator FloatConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Float and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Float.");

            return new FloatConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="FloatConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(FloatConstantHandle handle)
        {
            return new ConstantHandle( ConstantKind.Float,handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly FloatConstantHandle Nil = new(0);

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
