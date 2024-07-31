using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

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
            w.TryWriteU2(start);
            w.TryWriteU2(end);
            w.TryWriteU2(handler);
            w.TryWriteU2(catchType.Index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
