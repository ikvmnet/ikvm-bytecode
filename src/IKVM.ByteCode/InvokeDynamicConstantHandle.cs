using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a InvokeDynamic constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct InvokeDynamicConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to an <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.InvokeDynamic"/>.</exception>
        public static explicit operator InvokeDynamicConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.InvokeDynamic and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to InvokeDynamic.");

            return new InvokeDynamicConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts an <see cref="InvokeDynamicConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(InvokeDynamicConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.InvokeDynamic, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly InvokeDynamicConstantHandle Nil = new(0);

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
