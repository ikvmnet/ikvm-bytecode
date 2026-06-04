using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Package constant value.
    /// </summary>
    /// <param name="Name">The internal form of the package name.</param>
    public readonly record struct PackageConstant(string? Name)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="PackageConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Package"/> constant.</exception>
        public static explicit operator PackageConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Package)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Package.");

            return new PackageConstant((string?)value._object1);
        }

        /// <summary>
        /// Implicitly converts a <see cref="PackageConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(PackageConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Package, value.Name, null, null, 0);
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
