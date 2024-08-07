using System;

namespace IKVM.ByteCode
{

    public readonly record struct MethodHandleConstantHandle(ushort Index)
    {

        public static explicit operator MethodHandleConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.MethodHandle and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to MethodHandle.");

            return new MethodHandleConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(MethodHandleConstantHandle handle)
        {
            return new ConstantHandle( ConstantKind.MethodHandle, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly MethodHandleConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
