using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Ref constant value, including Fieldref, Methodref and InterfaceMethodref.
    /// </summary>
    /// <param name="Kind">The specific constant kind: <see cref="ConstantKind.Fieldref"/>, <see cref="ConstantKind.Methodref"/>, or <see cref="ConstantKind.InterfaceMethodref"/>.</param>
    /// <param name="ClassName">The internal name of the declaring class or interface.</param>
    /// <param name="Name">The simple name of the field or method.</param>
    /// <param name="Descriptor">The field or method descriptor.</param>
    public readonly record struct RefConstant(ConstantKind Kind, string? ClassName, string? Name, string? Descriptor)
    {

        /// <summary>
        /// Implicitly converts a generic <see cref="Constant"/> to a <see cref="RefConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a ref-type constant.</exception>
        public static implicit operator RefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Fieldref and not ConstantKind.Methodref and not ConstantKind.InterfaceMethodref)
                throw new InvalidCastException($"Cannot cast {nameof(Constant)} of kind {value.Kind} to {nameof(RefConstant)}.");

            return new RefConstant(value._kind, (string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        /// <summary>
        /// Implicitly converts a <see cref="RefConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(value.Kind, value.ClassName, value.Name, value.Descriptor, 0);
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
