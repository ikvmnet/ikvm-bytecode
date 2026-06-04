using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Class constant value.
    /// </summary>
    /// <param name="Name">The internal class name (e.g. <c>java/lang/Object</c>), or <c>null</c> for the nil instance.</param>
    public readonly record struct ClassConstant(string? Name)
    {

        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="ClassConstant"/>.
        /// </summary>
        /// <param name="value">The generic constant to convert.</param>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Class"/> constant.</exception>
        public static explicit operator ClassConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Class)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Class.");

            return new ClassConstant((string?)value._object1);
        }

        /// <summary>
        /// Implicitly converts a <see cref="ClassConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        /// <param name="value">The class constant to convert.</param>
        public static implicit operator Constant(ClassConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Class, value.Name, null,  null, 0);
        }

        /// <summary>
        /// Implicitly converts a <see cref="ClassConstant"/> to its internal name string.
        /// </summary>
        /// <param name="value">The class constant to convert.</param>
        /// <exception cref="NullReferenceException">Thrown when the instance is nil.</exception>
        public static implicit operator string?(ClassConstant value)
        {
            if (value.IsNil)
                throw new NullReferenceException();

            return value.Name;
        }

        /// <summary>
        /// Explicitly converts an internal class name string to a <see cref="ClassConstant"/>.
        /// </summary>
        /// <param name="value">The internal class name.</param>
        public static explicit operator ClassConstant(string value)
        {
            return Constant.Class(value);
        }

        readonly bool _isNotNil = true;

        /// <summary>Gets whether this instance is not nil.</summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>Gets whether this instance is nil.</summary>
        public readonly bool IsNil => !IsNotNil;

    }

}
