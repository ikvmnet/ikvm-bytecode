using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides support for building a table of class constants.
    /// </summary>
    public class ClassConstantTableBuilder
    {

        readonly ConstantBuilder _constants;
        BlobBuilder _builder;
        int _count = 0;

        /// <summary>
        /// Intializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public ClassConstantTableBuilder(ConstantBuilder constants)
        {
            _constants = constants ?? throw new ArgumentNullException(nameof(constants));
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        BlobBuilder Builder => _builder ??= new BlobBuilder();

        /// <summary>
        /// Increments the counter.
        /// </summary>
        void IncrementCount() => _count++;

        /// <summary>
        /// Adds a class to the table.
        /// </summary>
        /// <param name="clazz"></param>
        public void AddClass(ClassConstantHandle clazz)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(clazz.Value);
            IncrementCount();
        }

        /// <summary>
        /// Serialize the class constant table.
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
