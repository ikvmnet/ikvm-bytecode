using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Reading
{

    public sealed class InterfaceMethodrefConstantReader : RefConstantReader<InterfaceMethodrefConstantRecord>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal InterfaceMethodrefConstantReader(ClassReader declaringClass, InterfaceMethodrefConstantHandle handle, InterfaceMethodrefConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

    }

}