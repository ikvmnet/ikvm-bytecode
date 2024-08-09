using System;

namespace IKVM.ByteCode
{

    public readonly record struct MethodrefConstantHandle(ushort Index)
    {

        public static explicit operator MethodrefConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Methodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Methodref.");

            return new MethodrefConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(MethodrefConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Methodref, handle.Index);
        }

        public static explicit operator MethodrefConstantHandle(RefConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Methodref and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Methodref.");

            return new MethodrefConstantHandle(handle.Index);
        }

        public static implicit operator RefConstantHandle(MethodrefConstantHandle handle)
        {
            return new RefConstantHandle(ConstantKind.Methodref, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly MethodrefConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

        /// <summary>
        /// Gets whether or not this does not represent the nil instance.
        /// </summary>
        public readonly bool IsNotNil => !IsNil;

    }

}
