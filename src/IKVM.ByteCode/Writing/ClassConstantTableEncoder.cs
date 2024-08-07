﻿using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a class constant table structure.
    /// </summary>
    public struct ClassConstantTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Intializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ClassConstantTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a class to the table.
        /// </summary>
        /// <param name="clazz"></param>
        public ClassConstantTableEncoder Add(ClassConstantHandle clazz)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(clazz.Index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds multiple classes to the table.
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public ClassConstantTableEncoder AddMany(ReadOnlySpan<ClassConstantHandle> classes)
        {
            foreach (var i in classes)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds multiple classes to the table.
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public ClassConstantTableEncoder AddMany(IEnumerable<ClassConstantHandle> classes)
        {
            foreach (var i in classes)
                Add(i);

            return this;
        }

    }

}
