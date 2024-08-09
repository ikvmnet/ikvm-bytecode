using System;

namespace IKVM.ByteCode
{

    public readonly record struct RefConstant(ConstantKind Kind, string? ClassName, string? Name, string? Descriptor)
    {

        public static implicit operator RefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Fieldref and not ConstantKind.Methodref and not ConstantKind.InterfaceMethodref)
                throw new InvalidCastException($"Cannot cast RefConstantDescriptor of kind {value.Kind} to Ref.");

            return new RefConstant(value._kind, (string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        public static implicit operator Constant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(value.Kind, value.ClassName, value.Name, value.Descriptor, 0);
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
