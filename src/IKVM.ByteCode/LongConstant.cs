using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Long constant value.
    /// </summary>
    /// <param name="Value">The long value of this constant.</param>
    public readonly record struct LongConstant(long Value)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="LongConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Long"/> constant.</exception>
        public static explicit operator LongConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Long)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Long.");

            return new LongConstant((long)value._ulong1);
        }

        /// <summary>
        /// Implicitly converts a <see cref="LongConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(LongConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Long, null, null, null, (ulong)value.Value);
        }

        /// <summary>Explicitly converts a <see cref="LongConstant"/> to a <see cref="byte"/>.</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static explicit operator byte(LongConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (byte)value.Value;
        }

        /// <summary>Explicitly converts a <see cref="LongConstant"/> to a <see cref="short"/>.</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static explicit operator short(LongConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (short)value.Value;
        }

        /// <summary>Explicitly converts a <see cref="LongConstant"/> to an <see cref="int"/>.</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static explicit operator int(LongConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (int)value.Value;
        }

        /// <summary>Implicitly converts a <see cref="LongConstant"/> to a <see cref="long"/>.</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static implicit operator long(LongConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        /// <summary>Implicitly converts a <see cref="byte"/> to a <see cref="LongConstant"/>.</summary>
        public static implicit operator LongConstant(byte value)
        {
            return Constant.Long(value);
        }

        /// <summary>Implicitly converts a <see cref="short"/> to a <see cref="LongConstant"/>.</summary>
        public static implicit operator LongConstant(short value)
        {
            return Constant.Long(value);
        }

        /// <summary>Implicitly converts an <see cref="int"/> to a <see cref="LongConstant"/>.</summary>
        public static implicit operator LongConstant(int value)
        {
            return Constant.Long(value);
        }

        /// <summary>Implicitly converts a <see cref="long"/> to a <see cref="LongConstant"/>.</summary>
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
