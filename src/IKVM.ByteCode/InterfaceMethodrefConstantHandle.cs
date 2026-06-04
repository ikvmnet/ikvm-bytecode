using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a InterfaceMethodref constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct InterfaceMethodrefConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Converts a <see cref="ConstantHandle" /> to a <see cref="InterfaceMethodrefConstantHandle" />.
        /// </summary>
        /// <param name="handle">The handle to convert.</param>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.InterfaceMethodref"/>.</exception>
        public static explicit operator InterfaceMethodrefConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.InterfaceMethodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to InterfaceMethodref.");

            return new InterfaceMethodrefConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Converts a <see cref="InterfaceMethodrefConstantHandle" /> to a <see cref="ConstantHandle" />.
        /// </summary>
        /// <param name="handle">The handle to convert.</param>
        public static implicit operator ConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.InterfaceMethodref, handle.Slot);
        }

        /// <summary>
        /// Converts a <see cref="RefConstantHandle" /> to a <see cref="InterfaceMethodrefConstantHandle" />.
        /// </summary>
        /// <param name="handle">The handle to convert.</param>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.InterfaceMethodref"/>.</exception>
        public static explicit operator InterfaceMethodrefConstantHandle(RefConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.InterfaceMethodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"RefConstantHandle of Kind {handle.Kind} cannot be cast to InterfaceMethodref.");

            return new InterfaceMethodrefConstantHandle(handle.Index);
        }

        /// <summary>
        /// Converts a <see cref="InterfaceMethodrefConstantHandle" /> to a <see cref="RefConstantHandle" />.
        /// </summary>
        /// <param name="handle">The handle to convert.</param>
        public static implicit operator RefConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new RefConstantHandle(ConstantKind.InterfaceMethodref, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly InterfaceMethodrefConstantHandle Nil = new(0);

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
