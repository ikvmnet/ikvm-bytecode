using System;
using System.Collections.Generic;

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
        public AnnotationTableEncoder Add(Action<AnnotationEncoder> annotation)
        {
            annotation(new AnnotationEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Encodes an existing annotation.
        /// </summary>
        /// <param name="annotation"></param>
        public AnnotationTableEncoder Add(AnnotationRecord annotation)
        {
            return Add(e => e.Encode(annotation));
        }

        /// <summary>
        /// Encodes a new annotation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="elementValuePairs"></param>
        /// <returns></returns>
        public AnnotationTableEncoder Add(Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValuePairs)
        {
            return Add(e => e.Encode(type, elementValuePairs));
        }

        /// <summary>
        /// Adds multiple existing annotations.
        /// </summary>
        /// <param name="annotations"></param>
        /// <returns></returns>
        public AnnotationTableEncoder AddMany(ReadOnlySpan<AnnotationRecord> annotations)
        {
            foreach (var i in annotations)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds multiple existing annotations.
        /// </summary>
        /// <param name="annotations"></param>
        /// <returns></returns>
        public AnnotationTableEncoder AddMany(IEnumerable<AnnotationRecord> annotations)
        {
            foreach (var i in annotations)
                Add(i);

            return this;
        }

    }

}
