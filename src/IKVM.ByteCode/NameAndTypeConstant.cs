using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a NameAndType constant value.
    /// </summary>
    /// <param name="Name">The unqualified name of the field or method.</param>
    /// <param name="Descriptor">The field or method descriptor.</param>
    public readonly record struct NameAndTypeConstant(string? Name, string? Descriptor)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="NameAndTypeConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.NameAndType"/> constant.</exception>
        public static explicit operator NameAndTypeConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.NameAndType)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to NameAndType.");

            if (value._object1 is null)
                throw new InvalidOperationException();
            if (value._object2 is null)
                throw new InvalidOperationException();

            return new NameAndTypeConstant((string)value._object1, (string)value._object2);
        }

        /// <summary>
        /// Implicitly converts a <see cref="NameAndTypeConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(NameAndTypeConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.NameAndType, value.Name, value.Descriptor, null, 0);
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
