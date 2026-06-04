using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Class constant.
    /// </summary>
    /// <param name="Slot"></param>
    public readonly record struct ClassConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.Class"/>.</exception>
        public static explicit operator ClassConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Class and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Class.");

            return new ClassConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="ClassConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(ClassConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Class, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly ClassConstantHandle Nil = new(0);

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
