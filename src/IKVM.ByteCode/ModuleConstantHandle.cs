using System;

namespace IKVM.ByteCode
{

    public readonly record struct ModuleConstantHandle(ushort Slot)
    {

        public static explicit operator ModuleConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Module and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Module.");

            return new ModuleConstantHandle(handle.Slot);
        }

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
