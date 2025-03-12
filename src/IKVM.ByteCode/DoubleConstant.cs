using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Double constant value.
    /// </summary>
    /// <param name="Value"></param>
    public readonly record struct DoubleConstant(double Value)
    {

        public static explicit operator DoubleConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Double)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Double.");

            return new DoubleConstant(BitConverter.Int64BitsToDouble((long)value._ulong1));
        }

        public static implicit operator Constant(DoubleConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Double, null, null, null, (ulong)BitConverter.DoubleToInt64Bits(value.Value));
        }

        public static implicit operator double(DoubleConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

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
