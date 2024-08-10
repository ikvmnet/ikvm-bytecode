using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides support in building an exception table structure for the Code attribute.
    /// </summary>
    public struct ExceptionTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ExceptionTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a new exception region at the specified program location.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="handler"></param>
        /// <param name="catchType"></param>
        public ExceptionTableEncoder Exception(ushort start, ushort end, ushort handler, ClassConstantHandle catchType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(start);
            w.WriteU2(end);
            w.WriteU2(handler);
            w.WriteU2(catchType.Slot);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

    }

}
