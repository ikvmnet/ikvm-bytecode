using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a line number table.
    /// </summary>
    public struct LineNumberTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public LineNumberTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds an existing line number.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public LineNumberTableEncoder Add(LineNumberTableAttributeItemRecord record)
        {
            return LineNumber(record.CodeOffset, record.LineNumber);
        }

        /// <summary>
        /// Adds an existing line number.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public LineNumberTableEncoder AddMany(ReadOnlySpan<LineNumberTableAttributeItemRecord> records)
        {
            foreach (var i in records)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds an existing line number.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public LineNumberTableEncoder AddMany(IEnumerable<LineNumberTableAttributeItemRecord> records)
        {
            foreach (var i in records)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds a new line number at the specified byte code offset.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="lineNumber"></param>
        public LineNumberTableEncoder LineNumber(ushort start, ushort lineNumber)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(start);
            w.TryWriteU2(lineNumber);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
