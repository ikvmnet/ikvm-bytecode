namespace IKVM.ByteCode
{

    public readonly record struct ModuleConstantHandle(ushort Index)
    {

        public static explicit operator ModuleConstantHandle(Handle handle)
        {
            return new ModuleConstantHandle(handle.Index);
        }

        public static implicit operator Handle(ModuleConstantHandle handle)
        {
            return new Handle(handle.Index);
        }

        public static explicit operator ModuleConstantHandle(ConstantHandle handle)
        {
            return new ModuleConstantHandle(handle.Index);
        }

        public static implicit operator ConstantHandle(ModuleConstantHandle handle)
        {
            return new ConstantHandle(handle.Index);
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
