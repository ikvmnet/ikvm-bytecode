namespace IKVM.ByteCode
{

    /// <summary>
    /// Provides an interface which gets constant handles by their underlying values.
    /// </summary>
    public interface IConstantPool
    {

        /// <summary>
        /// Gets a <see cref="ConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ConstantHandle Get(Constant value);

        /// <summary>
        /// Gets a <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Utf8ConstantHandle Get(Utf8Constant value);

        /// <summary>
        /// Gets a <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IntegerConstantHandle Get(IntegerConstant value);

        /// <summary>
        /// Gets a <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        FloatConstantHandle Get(FloatConstant value);

        /// <summary>
        /// Gets a <see cref="LongConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        LongConstantHandle Get(LongConstant value);

        /// <summary>
        /// Gets a <see cref="DoubleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DoubleConstantHandle Get(DoubleConstant value);

        /// <summary>
        /// Gets a <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ClassConstantHandle Get(ClassConstant value);

        /// <summary>
        /// Gets a <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        StringConstantHandle Get(StringConstant value);

        /// <summary>
        /// Gets a <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        FieldrefConstantHandle Get(FieldrefConstant value);

        /// <summary>
        /// Gets a <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodrefConstantHandle Get(MethodrefConstant value);

        /// <summary>
        /// Gets a <see cref="InterfaceMethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        InterfaceMethodrefConstantHandle Get(InterfaceMethodrefConstant value);

        /// <summary>
        /// Gets a <see cref="NameAndTypeConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        NameAndTypeConstantHandle Get(NameAndTypeConstant value);

        /// <summary>
        /// Gets a <see cref="MethodHandleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodHandleConstantHandle Get(MethodHandleConstant value);

        /// <summary>
        /// Gets a <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodTypeConstantHandle Get(MethodTypeConstant value);

        /// <summary>
        /// Gets a <see cref="DynamicConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DynamicConstantHandle Get(DynamicConstant value);

        /// <summary>
        /// Gets a <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        InvokeDynamicConstantHandle Get(InvokeDynamicConstant value);

        /// <summary>
        /// Gets a <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ModuleConstantHandle Get(ModuleConstant value);

        /// <summary>
        /// Gets a <see cref="PackageConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        PackageConstantHandle Get(PackageConstant value);

    }

}
