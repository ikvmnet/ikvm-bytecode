using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a MethodType constant value.
    /// </summary>
    /// <param name="Descriptor"></param>
    public readonly record struct MethodTypeConstant(string? Descriptor)
    {


        public static explicit operator MethodTypeConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.MethodType)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to MethodType.");

            return new MethodTypeConstant((string?)value._object1);
        }

        public static implicit operator Constant(MethodTypeConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.MethodType, value.Descriptor, null, null, 0);
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
