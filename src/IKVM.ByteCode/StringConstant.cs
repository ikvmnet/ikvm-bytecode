using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a String constant value.
    /// </summary>
    /// <param name="Value"></param>
    public readonly record struct StringConstant(string? Value)
    {

        public static explicit operator StringConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.String)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to String.");

            return new StringConstant((string?)value._object1);
        }

        public static implicit operator Constant(StringConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.String, value.Value, null, null, 0);
        }

        public static implicit operator string?(StringConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Value;
        }

        public static explicit operator StringConstant(string value)
        {
            return Constant.String(value);
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
