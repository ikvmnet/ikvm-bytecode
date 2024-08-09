using System;

namespace IKVM.ByteCode
{

    public readonly record struct StringConstantHandle(ushort Index)
    {

        public static explicit operator StringConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.String and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to String.");

            return new StringConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(StringConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.String, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly StringConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

        /// <summary>
        /// Gets whether or not this does not represent the nil instance.
        /// </summary>
        public readonly bool IsNotNil => !IsNil;

    }

}
