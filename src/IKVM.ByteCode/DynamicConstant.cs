using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Dynamic constant value.
    /// </summary>
    /// <param name="BootstrapMethodAttributeIndex">The index into the <c>BootstrapMethods</c> attribute of the class file.</param>
    /// <param name="Name">The unqualified name of the constant.</param>
    /// <param name="Descriptor">The field descriptor indicating the type of the constant.</param>
    public readonly record struct DynamicConstant(ushort BootstrapMethodAttributeIndex, string? Name, string? Descriptor)
    {


        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="DynamicConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Dynamic"/> constant.</exception>
        public static explicit operator DynamicConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Dynamic)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to Dynamic.");

            return new DynamicConstant((ushort)value._ulong1, (string?)value._object1, (string?)value._object2);
        }

        /// <summary>
        /// Implicitly converts a <see cref="DynamicConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(DynamicConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Dynamic, value.Name, value.Descriptor, null, value.BootstrapMethodAttributeIndex);
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
