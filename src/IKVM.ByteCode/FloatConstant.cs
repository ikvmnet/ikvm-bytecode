using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode
{

    public readonly record struct FloatConstant(float Value)
    {

        public static explicit operator FloatConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Float)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Float.");

            return new FloatConstant(RawBitConverter.UInt32BitsToSingle((uint)value._ulong1));
        }

        public static implicit operator Constant(FloatConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Float, null, null, null, RawBitConverter.SingleToUInt32Bits(value.Value));
        }

        public static implicit operator float(FloatConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        public static implicit operator FloatConstant(float value)
        {
            return Constant.Float(value);
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
