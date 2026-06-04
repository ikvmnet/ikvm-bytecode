using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a MethodType constant value.
    /// </summary>
    /// <param name="Descriptor">The method descriptor.</param>
    public readonly record struct MethodTypeConstant(string? Descriptor)
    {


        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="MethodTypeConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.MethodType"/> constant.</exception>
        public static explicit operator MethodTypeConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.MethodType)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to MethodType.");

            return new MethodTypeConstant((string?)value._object1);
        }

        /// <summary>
        /// Implicitly converts a <see cref="MethodTypeConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(MethodTypeConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.MethodType, value.Descriptor, null, null, 0);
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
