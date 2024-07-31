using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Reading
{

    public sealed class MethodrefConstantReader : RefConstantReader<MethodrefConstantRecord>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal MethodrefConstantReader(ClassReader declaringClass, MethodrefConstantHandle handle, MethodrefConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

    }

}