using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Module constant.
    /// </summary>
    /// <param name="Slot">The constant pool slot index.</param>
    public readonly record struct ModuleConstantHandle(ushort Slot)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="ConstantHandle"/> to a <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the handle kind is not <see cref="ConstantKind.Module"/>.</exception>
        public static explicit operator ModuleConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Module and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Module.");

            return new ModuleConstantHandle(handle.Slot);
        }

        /// <summary>
        /// Implicitly converts a <see cref="ModuleConstantHandle"/> to a generic <see cref="ConstantHandle"/>.
        /// </summary>
        public static implicit operator ConstantHandle(ModuleConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Module, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly ModuleConstantHandle Nil = new(0);

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
