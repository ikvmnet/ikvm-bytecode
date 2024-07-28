namespace IKVM.ByteCode
{

    public readonly record struct ModuleConstantHandle(ushort Value)
    {

        public static explicit operator ModuleConstantHandle(Handle handle)
        {
            return new ModuleConstantHandle(handle.Value);
        }

        public static implicit operator Handle(ModuleConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator ModuleConstantHandle(ConstantHandle handle)
        {
            return new ModuleConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(ModuleConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

    }

}
