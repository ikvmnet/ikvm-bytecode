using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class DynamicConstantReader : ConstantReader<DynamicConstantRecord>
    {

        NameAndTypeConstantReader nameAndType;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="record"></param>
        internal DynamicConstantReader(ClassReader declaringClass, DynamicConstantHandle handle, DynamicConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <inheritdoc />
        public new DynamicConstantHandle Handle => (DynamicConstantHandle)base.Handle;

        public ushort BootstrapMethodAttributeIndex => Record.BootstrapMethodAttributeIndex;

        public NameAndTypeConstantReader NameAndType => LazyGet(ref nameAndType, () => DeclaringClass.Constants.Get<NameAndTypeConstantReader>(Record.NameAndType));

        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(55, 0);

    }

}
