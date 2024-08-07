using System;

namespace IKVM.ByteCode
{

    public readonly record struct IntegerConstantHandle(ushort Index)
    {

        public static explicit operator IntegerConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Integer and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Integer.");

            return new IntegerConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(IntegerConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Integer, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly IntegerConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
