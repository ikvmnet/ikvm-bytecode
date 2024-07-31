using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class InnerClassesAttributeItemReader : ReaderBase<InnerClassesAttributeItemRecord>
    {

        ClassConstantReader innerClass;
        ClassConstantReader outerClass;
        Utf8ConstantReader innerName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="record"></param>
        internal InnerClassesAttributeItemReader(ClassReader declaringClass, InnerClassesAttributeItemRecord record) :
            base(declaringClass, record)
        {

        }

        /// <summary>
        /// Gets the name of the inner class.
        /// </summary>
        public ClassConstantReader InnerClass => LazyGet(ref innerClass, () => DeclaringClass.Constants.Get<ClassConstantReader>(Record.InnerClass));

        /// <summary>
        /// Gets the name of the outer class.
        /// </summary>
        public ClassConstantReader OuterClass => LazyGet(ref outerClass, () => DeclaringClass.Constants.Get<ClassConstantReader>(Record.OuterClass));

        /// <summary>
        /// Gets the inner name.
        /// </summary>
        public Utf8ConstantReader InnerName => LazyGet(ref innerName, () => DeclaringClass.Constants.Get<Utf8ConstantReader>(Record.InnerName));

        /// <summary>
        /// Gets the access flags of the inner class.
        /// </summary>
        public AccessFlag InnerClassAccessFlags => Record.InnerClassAccessFlags;

    }

}
