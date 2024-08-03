﻿using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a table of 'type_annotation' structures.
    /// </summary>
    public struct TypeAnnotationTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public TypeAnnotationTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Encodes an existing annotation.
        /// </summary>
        /// <param name="record"></param>
        public TypeAnnotationTableEncoder Encode(TypeAnnotationRecord record)
        {
            return Annotation(e => e.Encode(record));
        }

        /// <summary>
        /// Adds an annotation.
        /// </summary>
        /// <param name="annotation"></param>
        public TypeAnnotationTableEncoder Annotation(Action<TypeAnnotationEncoder> annotation)
        {
            if (annotation is null)
                throw new ArgumentNullException(nameof(annotation));

            annotation(new TypeAnnotationEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
