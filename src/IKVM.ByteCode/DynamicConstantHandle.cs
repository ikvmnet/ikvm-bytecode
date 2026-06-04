using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Dynamic constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct DynamicConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="DynamicConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.Dynamic"/>.</exception>
        public static explicit operator DynamicConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Dynamic and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Dynamic.");

            return new DynamicConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="DynamicConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(DynamicConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Dynamic, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>  
        public static readonly DynamicConstantHandle Nil = new(0);

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
