using System;

namespace IKVM.ByteCode
{

    public readonly record struct DynamicConstant(ushort BootstrapMethodAttributeIndex, string? Name, string? Descriptor)
    {


        public static explicit operator DynamicConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Dynamic)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Dynamic.");

            return new DynamicConstant((ushort)value._ulong1, (string?)value._object1, (string?)value._object2);
        }

        public static implicit operator Constant(DynamicConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Dynamic, value.Name, value.Descriptor, null, value.BootstrapMethodAttributeIndex);
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
