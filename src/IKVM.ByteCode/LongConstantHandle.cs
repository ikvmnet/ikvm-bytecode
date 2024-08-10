using System;

namespace IKVM.ByteCode
{

    public readonly record struct LongConstantHandle(ushort Slot)
    {

        public static explicit operator LongConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Long and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Long.");

            return new LongConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(LongConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Long, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly LongConstantHandle Nil = new(0);

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
