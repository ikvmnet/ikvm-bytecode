using System;

namespace IKVM.ByteCode
{

    public readonly record struct Utf8Constant(string Value)
    {

        public static explicit operator Utf8Constant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Utf8)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Utf8.");

            if (value._object1 is null)
                throw new InvalidOperationException();

            return new Utf8Constant((string)value._object1);
        }

        public static implicit operator Constant(Utf8Constant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Utf8, value.Value, null, null, 0);
        }

        public static implicit operator string?(Utf8Constant value)
        {
            return value.IsNotNil ? value.Value : null;
        }

        public static implicit operator Utf8Constant(string value)
        {
            return Constant.Utf8(value);
        }

        readonly string? _value = Value;

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        public readonly string Value => _value ?? throw new InvalidOperationException("Utf8Constant is Nil.");

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => _value is null;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _value is not null;

    }

}
