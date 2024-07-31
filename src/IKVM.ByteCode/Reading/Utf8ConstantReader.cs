using IKVM.ByteCode.Parsing;
using IKVM.ByteCode.Text;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class Utf8ConstantReader : ConstantReader<Utf8ConstantRecord>
    {

        string value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal Utf8ConstantReader(ClassReader declaringClass, Utf8ConstantHandle handle, Utf8ConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <inheritdoc />
        public new Utf8ConstantHandle Handle => (Utf8ConstantHandle)base.Handle;

        /// <summary>
        /// Gets the value of the constant. Result is interned.
        /// </summary>
        public string Value => LazyGet(ref value, () => MUTF8Encoding.GetMUTF8(DeclaringClass.Version.Major).GetString(Record.Value));

    }

}
