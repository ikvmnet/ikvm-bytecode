using System;

namespace IKVM.ByteCode
{

    public readonly record struct ModuleConstantHandle(ushort Index)
    {

        public static explicit operator ModuleConstantHandle(ConstantHandle handle)
        {
            if (handle.Kind is not ConstantKind.Module and not ConstantKind.Unknown)
                throw new InvalidCastException($"ConstantHandle of Kind {handle.Kind} cannot be cast to Module.");

            return new ModuleConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(ModuleConstantHandle handle)
        {
            return new ConstantHandle(ConstantKind.Module, handle.Index);
        }

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly ModuleConstantHandle Nil = new(0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
