using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Class constant value.
    /// </summary>
    /// <param name="Name"></param>
    public readonly record struct ClassConstant(string? Name)
    {

        public static explicit operator ClassConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Class)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Class.");

            return new ClassConstant((string?)value._object1);
        }

        public static implicit operator Constant(ClassConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Class, value.Name, null,  null, 0);
        }

        public static implicit operator string?(ClassConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Name;
        }

        public static explicit operator ClassConstant(string value)
        {
            return Constant.Class(value);
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNotNil => _isNotNil;

        public readonly bool IsNil => !IsNotNil;

    }

}
