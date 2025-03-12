using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a String constant.
    /// </summary>
    /// <param name="Slot"></param>
    public readonly record struct StringConstantHandle(ushort Slot)
    {

        public static explicit operator StringConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.String and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to String.");

            return new StringConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(StringConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.String, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly StringConstantHandle Nil = new(0);

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
