using System;

namespace IKVM.ByteCode
{

    public readonly record struct LongConstantHandle(ushort Index)
    {

        public static explicit operator LongConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Long and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Long.");

            return new LongConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(LongConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Long, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly LongConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
