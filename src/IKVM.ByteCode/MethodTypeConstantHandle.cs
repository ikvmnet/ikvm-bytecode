using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a MethodType constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct MethodTypeConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.MethodType"/>.</exception>
        public static explicit operator MethodTypeConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.MethodType and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to MethodType.");

            return new MethodTypeConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="MethodTypeConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(MethodTypeConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.MethodType, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly MethodTypeConstantHandle Nil = new(0);

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
