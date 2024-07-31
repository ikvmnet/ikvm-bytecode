using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Reading
{

    public sealed class IntegerConstantReader : ConstantReader<IntegerConstantRecord>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal IntegerConstantReader(ClassReader declaringClass, IntegerConstantHandle handle, IntegerConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        public int Value => Record.Value;

        /// <inheritdoc />
        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(45, 3);

    }

}