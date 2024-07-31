using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class NameAndTypeConstantReader : ConstantReader<NameAndTypeConstantRecord>
    {

        Utf8ConstantReader name;
        Utf8ConstantReader type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal NameAndTypeConstantReader(ClassReader declaringClass, NameAndTypeConstantHandle handle, NameAndTypeConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <inheritdoc />
        public new NameAndTypeConstantHandle Handle => (NameAndTypeConstantHandle)base.Handle;

        /// <summary>
        /// Gets the name of this name and type constant.
        /// </summary>
        public Utf8ConstantReader Name => LazyGet(ref name, () => DeclaringClass.Constants.Get<Utf8ConstantReader>(Record.Name));

        /// <summary>
        /// Gets the type of this name and type constant.
        /// </summary>
        public Utf8ConstantReader Type => LazyGet(ref type, () => DeclaringClass.Constants.Get<Utf8ConstantReader>(Record.Descriptor));

    }

}
