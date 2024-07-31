using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    /// <summary>
    /// Base type for a ref constant reader.
    /// </summary>
    /// <typeparam name="TRecord"></typeparam>
    public abstract class RefConstantReader<TRecord> : ConstantReader<TRecord>, IRefConstantReader
        where TRecord : RefConstantRecord
    {

        ClassConstantReader clazz;
        NameAndTypeConstantReader name;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal RefConstantReader(ClassReader declaringClass, RefConstantHandle handle, TRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <inheritdoc />
        public new RefConstantHandle Handle => (RefConstantHandle)base.Handle;

        /// <summary>
        /// Gets the underlying record.
        /// </summary>
        RefConstantRecord IConstantReader<RefConstantRecord>.Record => Record;

        /// <summary>
        /// Gets the class name of the reference.
        /// </summary>
        public ClassConstantReader Class => LazyGet(ref clazz, () => DeclaringClass.Constants.Get<ClassConstantReader>(Record.Class));

        /// <summary>
        /// Gets the name and type of the reference.
        /// </summary>
        public NameAndTypeConstantReader NameAndType => LazyGet(ref name, () => DeclaringClass.Constants.Get<NameAndTypeConstantReader>(Record.NameAndType));

    }

}