using System;

namespace IKVM.ByteCode
{

    public readonly record struct Utf8ConstantHandle(ushort Slot)
    {

        public static explicit operator Utf8ConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Utf8 and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Utf8.");

            return new Utf8ConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(Utf8ConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Utf8, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly Utf8ConstantHandle Nil = new(0);

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
