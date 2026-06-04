using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a InterfaceMethodref constant value.
    /// </summary>
    /// <param name="ClassName">The internal name of the interface that declares the method.</param>
    /// <param name="Name">The simple name of the method.</param>
    /// <param name="Descriptor">The method descriptor.</param>
    public readonly record struct InterfaceMethodrefConstant(string? ClassName, string? Name, string? Descriptor)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to an <see cref="InterfaceMethodrefConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.InterfaceMethodref"/> constant.</exception>
        public static explicit operator InterfaceMethodrefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.InterfaceMethodref)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to InterfaceMethodref.");

            return new InterfaceMethodrefConstant((string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        /// <summary>
        /// Explicitly converts a <see cref="RefConstant"/> to an <see cref="InterfaceMethodrefConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.InterfaceMethodref"/> ref constant.</exception>
        public static explicit operator InterfaceMethodrefConstant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.InterfaceMethodref)
                throw new InvalidCastException($"Cannot cast RefConstantDescriptor of kind {value.Kind} to InterfaceMethodref.");

            return new InterfaceMethodrefConstant(value.ClassName, value.Name, value.Descriptor);
        }

        /// <summary>
        /// Implicitly converts an <see cref="InterfaceMethodrefConstant"/> to its generic <see cref="RefConstant"/> representation.
        /// </summary>
        public static implicit operator RefConstant(InterfaceMethodrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new RefConstant(ConstantKind.InterfaceMethodref, value.ClassName, value.Name, value.Descriptor);
        }

        /// <summary>
        /// Implicitly converts an <see cref="InterfaceMethodrefConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(InterfaceMethodrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.InterfaceMethodref, value.ClassName, value.Name, value.Descriptor, 0);
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
