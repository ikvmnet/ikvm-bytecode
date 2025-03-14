﻿using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a InvokeDynamic constant.
    /// </summary>
    /// <param name="Slot"></param>
    public readonly record struct InvokeDynamicConstantHandle(ushort Slot)
    {

        public static explicit operator InvokeDynamicConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.InvokeDynamic and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to InvokeDynamic.");

            return new InvokeDynamicConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(InvokeDynamicConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.InvokeDynamic, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly InvokeDynamicConstantHandle Nil = new(0);

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
