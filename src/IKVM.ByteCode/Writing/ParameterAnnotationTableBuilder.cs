using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public class ParameterAnnotationTableBuilder
    {

        BlobBuilder _builder;
        int _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ParameterAnnotationTableBuilder()
        {

        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        BlobBuilder Builder => _builder ??= new BlobBuilder();

        /// <summary>
        /// Adds an annotation.
        /// </summary>
        /// <param name="annotations"></param>
        public void AddParameterAnnotation(AnnotationTableBuilder annotations)
        {
            annotations.Serialize(Builder);
            _count++;
        }

        /// <summary>
        /// Serializes the exception table.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2((ushort)_count);
            if (_builder != null)
                builder.LinkSuffix(_builder);
        }

    }

}
