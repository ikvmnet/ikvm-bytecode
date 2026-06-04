using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Methodref constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct MethodrefConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.Methodref"/>.</exception>
        public static explicit operator MethodrefConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Methodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Methodref.");

            return new MethodrefConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="MethodrefConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(MethodrefConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Methodref, handle.Slot);
        }

        /// <summary>
        /// Explicitly converts a <see cref="RefConstantHandle"/> to a <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.Methodref"/>.</exception>
        public static explicit operator MethodrefConstantHandle(RefConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Methodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Methodref.");

            return new MethodrefConstantHandle(handle.Index);
        }

        /// <summary>
        /// Implicitly converts a <see cref="MethodrefConstantHandle"/> to a <see cref="RefConstantHandle"/>.
        /// </summary>
        public static implicit operator RefConstantHandle(MethodrefConstantHandle handle)
        {
            return new RefConstantHandle(ConstantKind.Methodref, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly MethodrefConstantHandle Nil = new(0);

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
