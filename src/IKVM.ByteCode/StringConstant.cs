using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a String constant value.
    /// </summary>
    /// <param name="Value">The string value, or <c>null</c> for the nil instance.</param>
    public readonly record struct StringConstant(string? Value)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="StringConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.String"/> constant.</exception>
        public static explicit operator StringConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.String)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to String.");

            return new StringConstant((string?)value._object1);
        }

        /// <summary>
        /// Implicitly converts a <see cref="StringConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(StringConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.String, value.Value, null, null, 0);
        }

        /// <summary>
        /// Implicitly converts a <see cref="StringConstant"/> to its string value.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static implicit operator string?(StringConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        /// <summary>
        /// Explicitly converts a string to a <see cref="StringConstant"/>.
        /// </summary>
        public static explicit operator StringConstant(string value)
        {
            return Constant.String(value);
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
