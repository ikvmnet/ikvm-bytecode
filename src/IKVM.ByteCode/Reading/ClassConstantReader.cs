using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class ClassConstantReader : ConstantReader<ClassConstantRecord>
    {

        Utf8ConstantReader name;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal ClassConstantReader(ClassReader declaringClass, ClassConstantHandle handle, ClassConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        public Utf8ConstantReader Name => LazyGet(ref name, () => DeclaringClass.Constants.Get<Utf8ConstantReader>(Record.Name));

        /// <summary>
        /// Returns whether or not this constant is loadable.
        /// </summary>
        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(49, 0);

    }

}