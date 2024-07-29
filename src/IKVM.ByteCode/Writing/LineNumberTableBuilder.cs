using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides support in building a line number table structure for the Code attribute.
    /// </summary>
    public class LineNumberTableBuilder
    {

        BlobBuilder _builder;
        int _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public LineNumberTableBuilder()
        {

        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        BlobBuilder Builder => _builder ??= new BlobBuilder();

        /// <summary>
        /// Adds a new line number at the specified byte code offset.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="lineNumber"></param>
        public void Add(ushort start, ushort lineNumber)
        {
            var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(start);
            w.TryWriteU2(lineNumber);
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
