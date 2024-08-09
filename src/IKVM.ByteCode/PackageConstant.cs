using System;

namespace IKVM.ByteCode
{

    public readonly record struct PackageConstant(string? Name)
    {

        public static explicit operator PackageConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Package)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Package.");

            return new PackageConstant((string?)value._object1);
        }

        public static implicit operator Constant(PackageConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Package, value.Name, null, null, 0);
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
