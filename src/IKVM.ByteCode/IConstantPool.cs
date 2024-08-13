using IKVM.ByteCode.Decoding;

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
        ConstantHandle Get(in Constant value);

        /// <summary>
        /// Gets a <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Utf8ConstantHandle Get(in Utf8Constant value);

        /// <summary>
        /// Gets a <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IntegerConstantHandle Get(in IntegerConstant value);

        /// <summary>
        /// Gets a <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        FloatConstantHandle Get(in FloatConstant value);

        /// <summary>
        /// Gets a <see cref="LongConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        LongConstantHandle Get(in LongConstant value);

        /// <summary>
        /// Gets a <see cref="DoubleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DoubleConstantHandle Get(in DoubleConstant value);

        /// <summary>
        /// Gets a <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ClassConstantHandle Get(in ClassConstant value);

        /// <summary>
        /// Gets a <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        StringConstantHandle Get(in StringConstant value);

        /// <summary>
        /// Gets a <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        FieldrefConstantHandle Get(in FieldrefConstant value);

        /// <summary>
        /// Gets a <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodrefConstantHandle Get(in MethodrefConstant value);

        /// <summary>
        /// Gets a <see cref="InterfaceMethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        InterfaceMethodrefConstantHandle Get(in InterfaceMethodrefConstant value);

        /// <summary>
        /// Gets a <see cref="NameAndTypeConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        NameAndTypeConstantHandle Get(in NameAndTypeConstant value);

        /// <summary>
        /// Gets a <see cref="MethodHandleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodHandleConstantHandle Get(in MethodHandleConstant value);

        /// <summary>
        /// Gets a <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodTypeConstantHandle Get(in MethodTypeConstant value);

        /// <summary>
        /// Gets a <see cref="DynamicConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DynamicConstantHandle Get(in DynamicConstant value);

        /// <summary>
        /// Gets a <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        InvokeDynamicConstantHandle Get(in InvokeDynamicConstant value);

        /// <summary>
        /// Gets a <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ModuleConstantHandle Get(in ModuleConstant value);

        /// <summary>
        /// Gets a <see cref="PackageConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        PackageConstantHandle Get(in PackageConstant value);

    }

}
