using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides support in building an exception table structure for the Code attribute.
    /// </summary>
    public class ExceptionTableBuilder
    {

        readonly ConstantBuilder _constants;
        BlobBuilder _builder;
        int _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public ExceptionTableBuilder(ConstantBuilder constants)
        {
            _constants = constants ?? throw new ArgumentNullException(nameof(constants));
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        BlobBuilder Builder => _builder ??= new BlobBuilder();

        /// <summary>
        /// Adds a new exception region at the specified program location.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="handler"></param>
        /// <param name="catchType"></param>
        public void AddException(ushort start, ushort end, ushort handler, ClassConstantHandle catchType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(start);
            w.TryWriteU2(end);
            w.TryWriteU2(handler);
            w.TryWriteU2(catchType.Value);
            _count++;
        }

        /// <summary>
        /// Adds a new exception region at the specified program location.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="handler"></param>
        /// <param name="catchType"></param>
        public void AddException(ushort start, ushort end, ushort handler, string catchType)
        {
            AddException(start, end, handler, catchType != null ? _constants.GetOrAddClassConstant(_constants.GetOrAddUtf8Constant(catchType)) : ClassConstantHandle.Nil);
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
