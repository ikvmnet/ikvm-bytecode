using System;

namespace IKVM.ByteCode
{

    public readonly record struct MethodTypeConstantHandle(ushort Slot)
    {

        public static explicit operator MethodTypeConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.MethodType and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to MethodType.");

            return new MethodTypeConstantHandle(handle.Slot);
        }

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
