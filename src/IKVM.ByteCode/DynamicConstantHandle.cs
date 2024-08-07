using System;

namespace IKVM.ByteCode
{

    public readonly record struct DynamicConstantHandle(ushort Index)
    {

        public static explicit operator DynamicConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Dynamic and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Dynamic.");

            return new DynamicConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(DynamicConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Dynamic, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly DynamicConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
