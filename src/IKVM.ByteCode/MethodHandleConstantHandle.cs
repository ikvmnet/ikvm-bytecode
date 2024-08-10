using System;

namespace IKVM.ByteCode
{

    public readonly record struct MethodHandleConstantHandle(ushort Slot)
    {

        public static explicit operator MethodHandleConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.MethodHandle and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to MethodHandle.");

            return new MethodHandleConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(MethodHandleConstantHandle handle)
        {
            return new ConstantHandle( ConstantKind.MethodHandle, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly MethodHandleConstantHandle Nil = new(0);

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
