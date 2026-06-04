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
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        Constant Get(ConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="Constant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        RefConstant Get(RefConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="Utf8Constant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        Utf8Constant Get(Utf8ConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="IntegerConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        IntegerConstant Get(IntegerConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="FloatConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        FloatConstant Get(FloatConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="LongConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        LongConstant Get(LongConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="DoubleConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        DoubleConstant Get(DoubleConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="ClassConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        ClassConstant Get(ClassConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        StringConstant Get(StringConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="FieldrefConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        FieldrefConstant Get(FieldrefConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="MethodrefConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        MethodrefConstant Get(MethodrefConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="InterfaceMethodrefConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        InterfaceMethodrefConstant Get(InterfaceMethodrefConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="NameAndTypeConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        NameAndTypeConstant Get(NameAndTypeConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="MethodHandleConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        MethodHandleConstant Get(MethodHandleConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="MethodTypeConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        MethodTypeConstant Get(MethodTypeConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="DynamicConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        DynamicConstant Get(DynamicConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        InvokeDynamicConstant Get(InvokeDynamicConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="ModuleConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        ModuleConstant Get(ModuleConstantHandle handle);

        /// <summary>
        /// Gets a <see cref="PackageConstant"/>.
        /// </summary>
        /// <param name="handle">The constant handle.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        PackageConstant Get(PackageConstantHandle handle);

    }

}
