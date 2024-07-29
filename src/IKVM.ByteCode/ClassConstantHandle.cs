namespace IKVM.ByteCode
{

    public readonly record struct ClassConstantHandle(ushort Value)
    {

        /// <summary>
        /// Gets the zero instance.
        /// </summary>
        public static readonly ClassConstantHandle Nil = new(0);

        public static explicit operator ClassConstantHandle(Handle handle)
        {
            return new ClassConstantHandle(handle.Value);
        }

        public static implicit operator Handle(ClassConstantHandle handle)
        {
            return new Handle(handle.Value);
        }

        public static explicit operator ClassConstantHandle(ConstantHandle handle)
        {
            return new ClassConstantHandle(handle.Value);
        }

        public static implicit operator ConstantHandle(ClassConstantHandle handle)
        {
            return new ConstantHandle(handle.Value);
        }

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Value == 0;

    }

}
