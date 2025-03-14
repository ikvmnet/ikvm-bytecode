﻿using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
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
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(_count);
        }

        /// <summary>
        /// Adds a class to the table.
        /// </summary>
        /// <param name="clazz"></param>
        public ClassConstantTableEncoder Class(ClassConstantHandle clazz)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(clazz.Slot);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds multiple classes to the table.
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public ClassConstantTableEncoder Classes(ReadOnlySpan<ClassConstantHandle> classes)
        {
            foreach (var i in classes)
                Class(i);

            return this;
        }

        /// <summary>
        /// Adds multiple classes to the table.
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public ClassConstantTableEncoder Classes(IEnumerable<ClassConstantHandle> classes)
        {
            foreach (var i in classes)
                Class(i);

            return this;
        }

    }

}
