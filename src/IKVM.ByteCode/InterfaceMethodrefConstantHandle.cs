using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a InterfaceMethodref constant.
    /// </summary>
    /// <param name="Slot"></param>
    public readonly record struct InterfaceMethodrefConstantHandle(ushort Slot)
    {

        public static explicit operator InterfaceMethodrefConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.InterfaceMethodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to InterfaceMethodref.");

            return new InterfaceMethodrefConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.InterfaceMethodref, handle.Slot);
        }

        public static explicit operator InterfaceMethodrefConstantHandle(RefConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.InterfaceMethodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"RefConstantHandle of Kind {handle.Kind} cannot be cast to InterfaceMethodref.");

            return new InterfaceMethodrefConstantHandle(handle.Index);
        }

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
