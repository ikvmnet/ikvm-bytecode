using System;

namespace IKVM.ByteCode
{

    public readonly record struct MethodrefConstant(string? ClassName, string? Name, string? Descriptor)
    {

        public static explicit operator MethodrefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Methodref)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Methodref.");

            return new MethodrefConstant((string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        public static explicit operator MethodrefConstant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Methodref)
                throw new InvalidCastException($"Cannot cast RefConstantDescriptor of kind {value.Kind} to Methodref.");

            return new MethodrefConstant(value.ClassName, value.Name, value.Descriptor);
        }

        public static implicit operator RefConstant(MethodrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new RefConstant(ConstantKind.Methodref, value.ClassName, value.Name, value.Descriptor);
        }

        public static implicit operator Constant(MethodrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Methodref, value.ClassName, value.Name, value.Descriptor, 0);
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
