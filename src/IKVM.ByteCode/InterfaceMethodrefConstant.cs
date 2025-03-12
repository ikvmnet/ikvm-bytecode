using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a InterfaceMethodref constant value.
    /// </summary>
    /// <param name="ClassName"></param>
    /// <param name="Name"></param>
    /// <param name="Descriptor"></param>
    public readonly record struct InterfaceMethodrefConstant(string? ClassName, string? Name, string? Descriptor)
    {

        public static explicit operator InterfaceMethodrefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.InterfaceMethodref)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to InterfaceMethodref.");

            return new InterfaceMethodrefConstant((string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        public static explicit operator InterfaceMethodrefConstant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.InterfaceMethodref)
                throw new InvalidCastException($"Cannot cast RefConstantDescriptor of kind {value.Kind} to InterfaceMethodref.");

            return new InterfaceMethodrefConstant(value.ClassName, value.Name, value.Descriptor);
        }

        public static implicit operator RefConstant(InterfaceMethodrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new RefConstant(ConstantKind.InterfaceMethodref, value.ClassName, value.Name, value.Descriptor);
        }

        public static implicit operator Constant(InterfaceMethodrefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.InterfaceMethodref, value.ClassName, value.Name, value.Descriptor, 0);
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
