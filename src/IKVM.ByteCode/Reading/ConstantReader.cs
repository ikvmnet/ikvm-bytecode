using IKVM.ByteCode.Parsing;
using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    /// <summary>
    /// Provides static methods for reading constants.
    /// </summary>
    public static class ConstantReader
    {

        /// <summary>
        /// Initializes a <see cref="IConstantReader"/> from a <see cref="ConstantRecord"/>.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        internal static IConstantReader Read(ClassReader declaringClass, ConstantHandle handle, ConstantRecord record) => record switch
        {
            Utf8ConstantRecord c => new Utf8ConstantReader(declaringClass, (Utf8ConstantHandle)handle, c),
            IntegerConstantRecord c => new IntegerConstantReader(declaringClass, (IntegerConstantHandle)handle, c),
            FloatConstantRecord c => new FloatConstantReader(declaringClass, (FloatConstantHandle)handle, c),
            LongConstantRecord c => new LongConstantReader(declaringClass, (LongConstantHandle)handle, c),
            DoubleConstantRecord c => new DoubleConstantReader(declaringClass, (DoubleConstantHandle)handle, c),
            ClassConstantRecord c => new ClassConstantReader(declaringClass, (ClassConstantHandle)handle, c),
            StringConstantRecord c => new StringConstantReader(declaringClass, (StringConstantHandle)handle, c),
            FieldrefConstantRecord c => new FieldrefConstantReader(declaringClass, (FieldrefConstantHandle)handle, c),
            MethodrefConstantRecord c => new MethodrefConstantReader(declaringClass, (MethodrefConstantHandle)handle, c),
            InterfaceMethodrefConstantRecord c => new InterfaceMethodrefConstantReader(declaringClass, (InterfaceMethodrefConstantHandle)handle, c),
            NameAndTypeConstantRecord c => new NameAndTypeConstantReader(declaringClass, (NameAndTypeConstantHandle)handle, c),
            MethodHandleConstantRecord c => new MethodHandleConstantReader(declaringClass, (MethodHandleConstantHandle)handle, c),
            MethodTypeConstantRecord c => new MethodTypeConstantReader(declaringClass, (MethodTypeConstantHandle)handle, c),
            DynamicConstantRecord c => new DynamicConstantReader(declaringClass, (DynamicConstantHandle)handle, c),
            InvokeDynamicConstantRecord c => new InvokeDynamicConstantReader(declaringClass, (InvokeDynamicConstantHandle)handle, c),
            ModuleConstantRecord c => new ModuleConstantReader(declaringClass, (ModuleConstantHandle)handle, c),
            PackageConstantRecord c => new PackageConstantReader(declaringClass, (PackageConstantHandle)handle, c),
            _ => throw new ByteCodeException($"Invalid constant type: {record.GetType().Name}"),
        };

    }

    /// <summary>
    /// Base type for constant readers.
    /// </summary>
    /// <typeparam name="TRecord"></typeparam>
    public abstract class ConstantReader<TRecord> : ReaderBase<TRecord>, IConstantReader<TRecord>
        where TRecord : ConstantRecord
    {

        readonly ConstantHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal protected ConstantReader(ClassReader declaringClass, ConstantHandle handle, TRecord record) :
            base(declaringClass, record)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the index of the constant.
        /// </summary>
        public ConstantHandle Handle => handle;

        /// <summary>
        /// Returns <c>true</c> if the constant is considered loadable according to the JVM specification.
        /// </summary>
        public virtual bool IsLoadable => false;

        /// <summary>
        /// Gets the underlying constant being read.
        /// </summary>
        TRecord IConstantReader<TRecord>.Record => Record;

    }

}
