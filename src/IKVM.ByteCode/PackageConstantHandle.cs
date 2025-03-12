using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a Package constant.
    /// </summary>
    /// <param name="Slot"></param>
    public readonly record struct PackageConstantHandle(ushort Slot)
    {

        public static explicit operator PackageConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Package and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Package.");

            return new PackageConstantHandle(handle.Slot);
        }

        public static implicit operator ConstantHandle(PackageConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Package, handle.Slot);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly PackageConstantHandle Nil = new(0);

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
