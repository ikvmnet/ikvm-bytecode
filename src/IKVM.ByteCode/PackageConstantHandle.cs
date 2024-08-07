using System;

namespace IKVM.ByteCode
{

    public readonly record struct PackageConstantHandle(ushort Index)
    {

        public static explicit operator PackageConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Package and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Package.");

            return new PackageConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(PackageConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Package, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly PackageConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
