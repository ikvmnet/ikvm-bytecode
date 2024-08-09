using System;

namespace IKVM.ByteCode
{

    public readonly record struct NameAndTypeConstantHandle(ushort Index)
    {

        public static explicit operator NameAndTypeConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.NameAndType and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to NameAndType.");

            return new NameAndTypeConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(NameAndTypeConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.NameAndType, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly NameAndTypeConstantHandle Nil = new(0);

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
