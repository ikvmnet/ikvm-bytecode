﻿using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    public struct TypePathEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        byte _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public TypePathEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U1);
            _count = 0;
        }

        /// <summary>
        /// Annotation is deeper in an array type.
        /// </summary>
        public TypePathEncoder Array()
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(0);
            w.TryWriteU1(0);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
            return this;
        }

        /// <summary>
        /// Annotation is deeper in a nested type.
        /// </summary>
        public TypePathEncoder InnerType()
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(1);
            w.TryWriteU1(0);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
            return this;
        }

        /// <summary>
        /// Annotation is on the bound of a wildcard type argument of a parameterized type.
        /// </summary>
        public TypePathEncoder Wildcard()
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(2);
            w.TryWriteU1(0);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
            return this;
        }

        /// <summary>
        /// Annotation is on the bound of a wildcard type argument of a parameterized type.
        /// </summary>
        public TypePathEncoder TypeArgument(byte index)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(3);
            w.TryWriteU1(index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
            return this;
        }
    }

}
