using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a Module constant value.
    /// </summary>
    /// <param name="Name">The module name.</param>
    public readonly record struct ModuleConstant(string? Name)
    {


        /// <summary>
        /// Explicitly converts a generic <see cref="Constant"/> to a <see cref="ModuleConstant"/>.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="value"/> is not a <see cref="ConstantKind.Module"/> constant.</exception>
        public static explicit operator ModuleConstant(Constant value)
        {
            if (value.IsNil)
                return default;

            if (value.Kind is not ConstantKind.Module)
                throw new InvalidCastException($"Cannot cast ConstantDescriptor of Kind {value.Kind} to Module.");

            return new ModuleConstant((string?)value._object1);
        }

        /// <summary>
        /// Implicitly converts a <see cref="ModuleConstant"/> to its generic <see cref="Constant"/> representation.
        /// </summary>
        public static implicit operator Constant(ModuleConstant value)
        {
            if (value.IsNil)
                return default;

            return new Constant(ConstantKind.Module, value.Name, null, null, 0);
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
