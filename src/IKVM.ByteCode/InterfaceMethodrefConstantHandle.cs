using System;

namespace IKVM.ByteCode
{

    public readonly record struct InterfaceMethodrefConstantHandle(ushort Index)
    {

        public static explicit operator InterfaceMethodrefConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.InterfaceMethodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to InterfaceMethodref.");

            return new InterfaceMethodrefConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.InterfaceMethodref, handle.Index);
        }

        public static explicit operator InterfaceMethodrefConstantHandle(RefConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.InterfaceMethodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"RefConstantHandle of Kind {handle.Kind} cannot be cast to InterfaceMethodref.");

            return new InterfaceMethodrefConstantHandle(handle.Index);
        }

        public static implicit operator RefConstantHandle(InterfaceMethodrefConstantHandle handle)
        {
            return new RefConstantHandle(ConstantKind.InterfaceMethodref, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly InterfaceMethodrefConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
