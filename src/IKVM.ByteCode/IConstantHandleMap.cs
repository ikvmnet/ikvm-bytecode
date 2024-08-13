using IKVM.ByteCode.Decoding;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Describes an interface that can map from one constant handle to another.
    /// </summary>
    public interface IConstantHandleMap : IConstantView
    {

        /// <summary>
        /// Maps a <see cref="ConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ConstantHandle Map(ConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Utf8ConstantHandle Map(Utf8ConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IntegerConstantHandle Map(IntegerConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        FloatConstantHandle Map(FloatConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="LongConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        LongConstantHandle Map(LongConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="DoubleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DoubleConstantHandle Map(DoubleConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ClassConstantHandle Map(ClassConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        StringConstantHandle Map(StringConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        FieldrefConstantHandle Map(FieldrefConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodrefConstantHandle Map(MethodrefConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="InterfaceMethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        InterfaceMethodrefConstantHandle Map(InterfaceMethodrefConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="NameAndTypeConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        NameAndTypeConstantHandle Map(NameAndTypeConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="MethodHandleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodHandleConstantHandle Map(MethodHandleConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        MethodTypeConstantHandle Map(MethodTypeConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="DynamicConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DynamicConstantHandle Map(DynamicConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        InvokeDynamicConstantHandle Map(InvokeDynamicConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ModuleConstantHandle Map(ModuleConstantHandle handle);

        /// <summary>
        /// Maps a <see cref="PackageConstantHandle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        PackageConstantHandle Map(PackageConstantHandle handle);

    }

}
