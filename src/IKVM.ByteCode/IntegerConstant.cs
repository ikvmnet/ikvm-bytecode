using System;

namespace IKVM.ByteCode
{

    public readonly record struct IntegerConstant(int Value)
    {

        public static explicit operator IntegerConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Integer)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Integer.");

            return new IntegerConstant((int)(long)value._ulong1);
        }

        public static implicit operator Constant(IntegerConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Integer, null, null, null, (ulong)(long)value.Value);
        }

        public static explicit operator bool(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value != 0;
        }

        public static explicit operator byte(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (byte)(sbyte)value.Value;
        }

        public static explicit operator short(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (short)value.Value;
        }

        public static implicit operator int(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        public static implicit operator long(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        public static implicit operator IntegerConstant(bool value)
        {
            return Constant.Integer(value ? 1 : 0);
        }

        public static implicit operator IntegerConstant(byte value)
        {
            return Constant.Integer(value);
        }

        public static implicit operator IntegerConstant(short value)
        {
            return Constant.Integer(value);
        }

        public static implicit operator IntegerConstant(int value)
        {
            return Constant.Integer(value);
        }

        public static explicit operator IntegerConstant(long value)
        {
            return Constant.Integer((int)value);
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
