using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Reading
{

    public sealed class FloatConstantReader : ConstantReader<FloatConstantRecord>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal FloatConstantReader(ClassReader declaringClass, FloatConstantHandle handle, FloatConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        public float Value => Record.Value;

        /// <summary>
        /// Returns <c>true</c> if this constant is loadable.
        /// </summary>
        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(45, 3);

    }

}