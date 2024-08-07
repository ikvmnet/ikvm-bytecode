using System;

namespace IKVM.ByteCode
{

    public readonly record struct Utf8ConstantHandle(ushort Index)
    {

        public static explicit operator Utf8ConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Utf8 and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Utf8.");

            return new Utf8ConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(Utf8ConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Utf8, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly Utf8ConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
