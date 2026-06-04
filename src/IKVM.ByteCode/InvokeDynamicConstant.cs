using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents an InvokeDynamic constant value.
    /// </summary>
    /// <param name="BootstrapMethodAttributeIndex">The index into the <c>BootstrapMethods</c> attribute of the class file.</param>
    /// <param name="Name">The unqualified name of the method.</param>
    /// <param name="Descriptor">The method descriptor.</param>
    public readonly record struct InvokeDynamicConstant(ushort BootstrapMethodAttributeIndex, string? Name, string? Descriptor)
    {


        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to an <see cref="InvokeDynamicConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.InvokeDynamic"/> constant.</exception>
        public static explicit operator InvokeDynamicConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.InvokeDynamic)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of kind {value.Kind} to InvokeDynamic.");

            return new InvokeDynamicConstant((ushort)value._ulong1, (string?)value._object1, (string?)value._object2);
        }

        /// <summary>
        /// Implicitly converts an <see cref="InvokeDynamicConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(InvokeDynamicConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.InvokeDynamic, value.Name, value.Descriptor, null, value.BootstrapMethodAttributeIndex);
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
