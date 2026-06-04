using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Methodref constant value.
    /// </summary>
    /// <param name="ClassName">The internal name of the class that declares the method.</param>
    /// <param name="Name">The simple name of the method.</param>
    /// <param name="Descriptor">The method descriptor.</param>
    public readonly record struct MethodrefConstant(string? ClassName, string? Name, string? Descriptor)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="MethodrefConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Methodref"/> constant.</exception>
        public static explicit operator MethodrefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Methodref)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Methodref.");

            return new MethodrefConstant((string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        /// <summary>
        /// Explicitly converts a <see cref="RefConstant"/> to a <see cref="MethodrefConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Methodref"/> ref constant.</exception>
        public static explicit operator MethodrefConstant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Methodref)
                throw new InvalidCastException($"Cannot cast RefConstantDescriptor of kind {value.Kind} to Methodref.");

            return new MethodrefConstant(value.ClassName, value.Name, value.Descriptor);
        }

        /// <summary>
        /// Implicitly converts a <see cref="MethodrefConstant"/> to its generic <see cref="RefConstant"/> representation.
        /// </summary>
        public static implicit operator RefConstant(MethodrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new RefConstant(ConstantKind.Methodref, value.ClassName, value.Name, value.Descriptor);
        }

        /// <summary>
        /// Implicitly converts a <see cref="MethodrefConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(MethodrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Methodref, value.ClassName, value.Name, value.Descriptor, 0);
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
