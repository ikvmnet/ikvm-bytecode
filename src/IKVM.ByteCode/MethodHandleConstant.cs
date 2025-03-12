using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a MethodHandle constant value.
    /// </summary>
    /// <param name="Kind"></param>
    /// <param name="ReferenceKind"></param>
    /// <param name="ClassName"></param>
    /// <param name="Name"></param>
    /// <param name="Descriptor"></param>
    public readonly record struct MethodHandleConstant(MethodHandleKind Kind, ConstantKind ReferenceKind, string? ClassName, string? Name, string? Descriptor)
    {

        public static explicit operator MethodHandleConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.MethodHandle)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to MethodHandle.");

            return new MethodHandleConstant((MethodHandleKind)(byte)(value._ulong1 >> 32), (ConstantKind)(byte)(value._ulong1 & 0x00000000FFFFFFFF), (string?)value._object1, (string?)value._object2, (string?)value._object3);
        }

        public static implicit operator Constant(MethodHandleConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.MethodHandle, value.ClassName, value.Name, value.Descriptor, (ulong)(byte)value.Kind << 32 | (ulong)(byte)value.ReferenceKind);
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
