using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Reading
{

    public class FieldrefConstantReader : RefConstantReader<FieldrefConstantRecord>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal FieldrefConstantReader(ClassReader declaringClass, FieldrefConstantHandle handle, FieldrefConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <inheritdoc />
        public new FieldrefConstantHandle Handle => (FieldrefConstantHandle)base.Handle;

    }

}
