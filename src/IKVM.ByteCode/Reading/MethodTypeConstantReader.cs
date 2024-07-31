using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class MethodTypeConstantReader : ConstantReader<MethodTypeConstantRecord>
    {

        Utf8ConstantReader type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal MethodTypeConstantReader(ClassReader owner, MethodTypeConstantHandle handle, MethodTypeConstantRecord record) :
            base(owner, handle, record)
        {

        }

        /// <summary>
        /// Gets the type of this MethodType constant.
        /// </summary>
        public Utf8ConstantReader Type => LazyGet(ref type, () => DeclaringClass.Constants.Get<Utf8ConstantReader>(Record.Descriptor));

        /// <summary>
        /// Returns <c>true</c> if this constant is loadable.
        /// </summary>
        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(51, 0);

    }

}
