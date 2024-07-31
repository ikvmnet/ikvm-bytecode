using IKVM.ByteCode.Parsing;
using IKVM.ByteCode.Writing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class InvokeDynamicConstantReader : ConstantReader<InvokeDynamicConstantRecord>
    {

        NameAndTypeConstantReader nameAndType;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal InvokeDynamicConstantReader(ClassReader owner, InvokeDynamicConstantHandle handle, InvokeDynamicConstantRecord record) :
            base(owner, handle, record)
        {

        }

        /// <inheritdoc />
        public new InvokeDynamicConstantHandle Handle => (InvokeDynamicConstantHandle)base.Handle;

        /// <summary>
        /// Gets the index into the BootstrapMethod table that is referenced by this constant.
        /// </summary>
        public ushort BootstrapMethodAttributeIndex => Record.BootstrapMethodAttributeIndex;

        /// <summary>
        /// Gets the name of the InvokeDynamic constant.
        /// </summary>
        public NameAndTypeConstantReader NameAndType => LazyGet(ref nameAndType, () =>  DeclaringClass.Constants.Get<NameAndTypeConstantReader>(Record.NameAndType));

    }

}
