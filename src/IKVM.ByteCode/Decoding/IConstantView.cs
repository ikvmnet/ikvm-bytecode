namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Provides an interface that allows resolution of a constant handle given a constant value.
    /// </summary>
    public interface IConstantView
    {

        /// <summary>
        /// Gets a <see cref="Constant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        Constant Get(ConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="Constant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        RefConstant Get(RefConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="Utf8Constant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        Utf8Constant Get(Utf8ConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="IntegerConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        IntegerConstant Get(IntegerConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="FloatConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        FloatConstant Get(FloatConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="LongConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        LongConstant Get(LongConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="DoubleConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        DoubleConstant Get(DoubleConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="ClassConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        ClassConstant Get(ClassConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        StringConstant Get(StringConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="FieldrefConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        FieldrefConstant Get(FieldrefConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="MethodrefConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        MethodrefConstant Get(MethodrefConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="InterfaceMethodrefConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        InterfaceMethodrefConstant Get(InterfaceMethodrefConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="NameAndTypeConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        NameAndTypeConstant Get(NameAndTypeConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="MethodHandleConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        MethodHandleConstant Get(MethodHandleConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="MethodTypeConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        MethodTypeConstant Get(MethodTypeConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="DynamicConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        DynamicConstant Get(DynamicConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        InvokeDynamicConstant Get(InvokeDynamicConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="ModuleConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        ModuleConstant Get(ModuleConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="PackageConstant"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        PackageConstant Get(PackageConstantHandle handle);

    }

}
