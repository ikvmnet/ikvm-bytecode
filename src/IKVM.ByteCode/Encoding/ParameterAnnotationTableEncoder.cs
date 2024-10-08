﻿using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
{

    public struct ParameterAnnotationTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        byte _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ParameterAnnotationTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U1);
            _count = 0;
        }

        /// <summary>
        /// Adds an annotation.
        /// </summary>
        /// <param name="annotations"></param>
        public ParameterAnnotationTableEncoder ParameterAnnotation(Action<AnnotationTableEncoder> annotations)
        {
            annotations(new AnnotationTableEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU1(++_count);
            return this;
        }

    }

}
