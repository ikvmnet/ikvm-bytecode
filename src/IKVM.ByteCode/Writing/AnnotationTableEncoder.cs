using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes an annotation table.
    /// </summary>
    public struct AnnotationTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public AnnotationTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds an annotation.
        /// </summary>
        /// <param name="annotation"></param>
        public AnnotationTableEncoder Annotation(Action<AnnotationEncoder> annotation)
        {
            annotation(new AnnotationEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
