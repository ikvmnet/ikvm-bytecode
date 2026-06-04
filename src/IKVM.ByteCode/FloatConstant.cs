using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Float constant value.
    /// </summary>
    /// <param name="Value">The float value of this constant.</param>
    public readonly record struct FloatConstant(float Value)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="FloatConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Float"/> constant.</exception>
        public static explicit operator FloatConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Float)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Float.");

            return new FloatConstant(RawBitConverter.UInt32BitsToSingle((uint)value._ulong1));
        }

        /// <summary>
        /// Implicitly converts a <see cref="FloatConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(FloatConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Float, null, null, null, RawBitConverter.SingleToUInt32Bits(value.Value));
        }

        /// <summary>
        /// Implicitly converts a <see cref="FloatConstant"/> to its <see cref="float"/> value.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static implicit operator float(FloatConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        /// <summary>
        /// Implicitly converts a <see cref="float"/> to a <see cref="FloatConstant"/>.
        /// </summary>
        public static implicit operator FloatConstant(float value)
        {
            return Constant.Float(value);
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
