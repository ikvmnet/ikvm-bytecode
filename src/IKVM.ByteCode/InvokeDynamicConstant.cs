using System;

namespace IKVM.ByteCode
{

    public readonly record struct InvokeDynamicConstant(ushort BootstrapMethodAttributeIndex, string? Name, string? Descriptor)
    {


        public static explicit operator InvokeDynamicConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.InvokeDynamic)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to InvokeDynamic.");

            return new InvokeDynamicConstant((ushort)value._ulong1, (string?)value._object1, (string?)value._object2);
        }

        public static implicit operator Constant(InvokeDynamicConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.InvokeDynamic, value.Name, value.Descriptor, null, value.BootstrapMethodAttributeIndex);
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
