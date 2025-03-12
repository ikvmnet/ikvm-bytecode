using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Float constant.
    /// </summary>
    /// <param name="Slot"></param>
    public readonly record struct FloatConstantHandle(ushort Slot)
    {

        public static explicit operator FloatConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Float and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Float.");

            return new FloatConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(FloatConstantHandle handle)
        {
            return new ConstantHandle( ConstantKind.Float,handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly FloatConstantHandle Nil = new(0);

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
