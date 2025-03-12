using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Long constant value.
    /// </summary>
    /// <param name="Value"></param>
    public readonly record struct LongConstant(long Value)
    {

        public static explicit operator LongConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Long)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Long.");

            return new LongConstant((long)value._ulong1);
        }

        public static implicit operator Constant(LongConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Long, null, null, null, (ulong)value.Value);
        }

        public static explicit operator byte(LongConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (byte)value.Value;
        }

        public static explicit operator short(LongConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (short)value.Value;
        }

        public static explicit operator int(LongConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (int)value.Value;
        }

        public static implicit operator long(LongConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        public static implicit operator LongConstant(byte value)
        {
            return Constant.Long(value);
        }

        public static implicit operator LongConstant(short value)
        {
            return Constant.Long(value);
        }

        public static implicit operator LongConstant(int value)
        {
            return Constant.Long(value);
        }

        public static implicit operator LongConstant(long value)
        {
            return Constant.Long(value);
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
