using System;

namespace IKVM.ByteCode
{

    public readonly record struct ModuleConstant(string? Name)
    {


        public static explicit operator ModuleConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Module)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Module.");

            return new ModuleConstant((string?)value._object1);
        }

        public static implicit operator Constant(ModuleConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Module, value.Name, null, null, 0);
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
