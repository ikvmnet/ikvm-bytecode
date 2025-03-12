using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Dynamic constant.
    /// </summary>
    /// <param name="Slot"></param>
    public readonly record struct DynamicConstantHandle(ushort Slot)
    {

        public static explicit operator DynamicConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Dynamic and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Dynamic.");

            return new DynamicConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(DynamicConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Dynamic, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>  
        public static readonly DynamicConstantHandle Nil = new(0);

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
