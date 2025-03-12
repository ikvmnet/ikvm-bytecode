using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Ref constant value, including Fieldref, Methodref and InterfaceMethodref.
    /// </summary>
    /// <param name="Kind"></param>
    /// <param name="ClassName"></param>
    /// <param name="Name"></param>
    /// <param name="Descriptor"></param>
    public readonly record struct RefConstant(ConstantKind Kind, string? ClassName, string? Name, string? Descriptor)
    {

        public static implicit operator RefConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Fieldref and not ConstantKind.Methodref and not ConstantKind.InterfaceMethodref)
                throw new InvalidCastException($"Cannot cast {nameof(Constant)} of kind {value.Kind} to {nameof(RefConstant)}.");

            return new RefConstant(value._kind, (string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        public static implicit operator Constant(RefConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(value.Kind, value.ClassName, value.Name, value.Descriptor, 0);
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
