using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents an Integer constant value.
    /// </summary>
    /// <param name="Value">The integer value of this constant.</param>
    public readonly record struct IntegerConstant(int Value)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to an <see cref="IntegerConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Integer"/> constant.</exception>
        public static explicit operator IntegerConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Integer)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Integer.");

            return new IntegerConstant((int)(long)value._ulong1);
        }

        /// <summary>
        /// Implicitly converts an <see cref="IntegerConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(IntegerConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Integer, null, null, null, (ulong)(long)value.Value);
        }

        /// <summary>Explicitly converts an <see cref="IntegerConstant"/> to a <see cref="bool"/> (<c>0</c> is <c>false</c>, any other value is <c>true</c>).</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static explicit operator bool(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value != 0;
        }

        /// <summary>Explicitly converts an <see cref="IntegerConstant"/> to a <see cref="byte"/>.</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static explicit operator byte(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (byte)(sbyte)value.Value;
        }

        /// <summary>Explicitly converts an <see cref="IntegerConstant"/> to a <see cref="short"/>.</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static explicit operator short(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return (short)value.Value;
        }

        /// <summary>Implicitly converts an <see cref="IntegerConstant"/> to an <see cref="int"/>.</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static implicit operator int(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        /// <summary>Implicitly converts an <see cref="IntegerConstant"/> to a <see cref="long"/>.</summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static implicit operator long(IntegerConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        /// <summary>Implicitly converts a <see cref="bool"/> to an <see cref="IntegerConstant"/>.</summary>
        public static implicit operator IntegerConstant(bool value)
        {
            return Constant.Integer(value ? 1 : 0);
        }

        /// <summary>Implicitly converts a <see cref="byte"/> to an <see cref="IntegerConstant"/>.</summary>
        public static implicit operator IntegerConstant(byte value)
        {
            return Constant.Integer(value);
        }

        /// <summary>Implicitly converts a <see cref="short"/> to an <see cref="IntegerConstant"/>.</summary>
        public static implicit operator IntegerConstant(short value)
        {
            return Constant.Integer(value);
        }

        /// <summary>Implicitly converts an <see cref="int"/> to an <see cref="IntegerConstant"/>.</summary>
        public static implicit operator IntegerConstant(int value)
        {
            return Constant.Integer(value);
        }

        /// <summary>Explicitly converts a <see cref="long"/> to an <see cref="IntegerConstant"/> (truncated to 32 bits).</summary>
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
