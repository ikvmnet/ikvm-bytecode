using System;

using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode
{

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

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
