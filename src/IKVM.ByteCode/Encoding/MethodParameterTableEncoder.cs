﻿using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
{

    /// <summary>
    /// Encoes a method parameters structure.
    /// </summary>
    public struct MethodParameterTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        byte _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public MethodParameterTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U1);
            _count = 0;
        }

        /// <summary>
        /// Adds a parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="accessFlags"></param>
        /// <returns></returns>
        public MethodParameterTableEncoder MethodParameter(Utf8ConstantHandle name, AccessFlag accessFlags)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(name.Slot);
            w.WriteU2((ushort)accessFlags);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU1(++_count);
            return this;
        }

    }

}
