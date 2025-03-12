using System;

namespace IKVM.ByteCode
{

    public readonly record struct FieldrefConstant(string? ClassName, string? Name, string? Descriptor)
    {

        public static explicit operator FieldrefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Fieldref)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Fieldref.");

            return new FieldrefConstant((string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        public static explicit operator FieldrefConstant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Fieldref)
                throw new InvalidCastException($"Cannot cast RefConstantDescriptor of kind {value.Kind} to Fieldref.");

            return new FieldrefConstant(value.ClassName, value.Name, value.Descriptor);
        }

        public static implicit operator RefConstant(FieldrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new RefConstant(ConstantKind.Fieldref, value.ClassName, value.Name, value.Descriptor);
        }

        public static implicit operator Constant(FieldrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Fieldref, value.ClassName, value.Name, value.Descriptor, 0);
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
