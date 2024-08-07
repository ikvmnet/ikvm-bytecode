using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a package constant table structure.
    /// </summary>
    public struct RecordComponentTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Intializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public RecordComponentTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a component.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public RecordComponentTableEncoder RecordComponent(Utf8ConstantHandle name, Utf8ConstantHandle descriptor, AttributeTableBuilder attributes)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(name.Index);
            w.TryWriteU2(descriptor.Index);
            attributes.Serialize(_builder);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
