using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Double constant value.
    /// </summary>
    /// <param name="Value">The double value of this constant.</param>
    public readonly record struct DoubleConstant(double Value)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="DoubleConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Double"/> constant.</exception>
        public static explicit operator DoubleConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Double)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Double.");

            return new DoubleConstant(BitConverter.Int64BitsToDouble((long)value._ulong1));
        }

        /// <summary>
        /// Implicitly converts a <see cref="DoubleConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(DoubleConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Double, null, null, null, (ulong)BitConverter.DoubleToInt64Bits(value.Value));
        }

        /// <summary>
        /// Implicitly converts a <see cref="DoubleConstant"/> to its <see cref="double"/> value.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static implicit operator double(DoubleConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        /// <summary>
        /// Implicitly converts a <see cref="double"/> to a <see cref="DoubleConstant"/>.
        /// </summary>
        public static implicit operator DoubleConstant(double value)
        {
            return Constant.Double(value);
        }

        readonly bool _isNotNil = true;
        readonly double _value = Value;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        public readonly double Value => IsNotNil ? _value : throw new InvalidOperationException("DoubleConstant is Nil.");

    }

}
