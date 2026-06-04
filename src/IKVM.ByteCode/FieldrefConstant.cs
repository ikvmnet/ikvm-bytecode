using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Fieldref constant value.
    /// </summary>
    /// <param name="ClassName">The internal name of the class that declares the field.</param>
    /// <param name="Name">The simple name of the field.</param>
    /// <param name="Descriptor">The field descriptor.</param>
    public readonly record struct FieldrefConstant(string? ClassName, string? Name, string? Descriptor)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="FieldrefConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Fieldref"/> constant.</exception>
        public static explicit operator FieldrefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Fieldref)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Fieldref.");

            return new FieldrefConstant((string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        /// <summary>
        /// Explicitly converts a <see cref="RefConstant"/> to a <see cref="FieldrefConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Fieldref"/> ref constant.</exception>
        public static explicit operator FieldrefConstant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Fieldref)
                throw new InvalidCastException($"Cannot cast RefConstantDescriptor of kind {value.Kind} to Fieldref.");

            return new FieldrefConstant(value.ClassName, value.Name, value.Descriptor);
        }

        /// <summary>
        /// Implicitly converts a <see cref="FieldrefConstant"/> to its generic <see cref="RefConstant"/> representation.
        /// </summary>
        public static implicit operator RefConstant(FieldrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new RefConstant(ConstantKind.Fieldref, value.ClassName, value.Name, value.Descriptor);
        }

        /// <summary>
        /// Implicitly converts a <see cref="FieldrefConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(FieldrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Fieldref, value.ClassName, value.Name, value.Descriptor, 0);
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
