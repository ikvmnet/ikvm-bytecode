using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class StringConstantReader : ConstantReader<StringConstantRecord>
    {

        Utf8ConstantReader value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal StringConstantReader(ClassReader declaringClass, StringConstantHandle handle, StringConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <summary>
        /// Gets the value of the string constant. Result may not actually be a string object as overrides can apply.
        /// </summary>
        public Utf8ConstantReader Value => LazyGet(ref value, () => DeclaringClass.Constants.Get<Utf8ConstantReader>(Record.Value));

        /// <summary>
        /// Returns <c>true</c> if this class is loadable according to the Java specification.
        /// </summary>
        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(45, 3);

    }

}