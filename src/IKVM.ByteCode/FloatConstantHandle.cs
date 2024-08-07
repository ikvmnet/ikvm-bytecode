using System;

namespace IKVM.ByteCode
{

    public readonly record struct FloatConstantHandle(ushort Index)
    {

        public static explicit operator FloatConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Float and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Float.");

            return new FloatConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(FloatConstantHandle handle)
        {
            return new ConstantHandle( ConstantKind.Float,handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly FloatConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
