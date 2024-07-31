using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Reading
{

    public sealed class DoubleConstantReader : ConstantReader<DoubleConstantRecord>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal DoubleConstantReader(ClassReader declaringClass, DoubleConstantHandle handle, DoubleConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        public double Value => Record.Value;

        /// <summary>
        /// Returns whether or not this constant is loadable.
        /// </summary>
        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(45, 3);

    }

}