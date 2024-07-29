using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public class ElementValuePairTableBuilder
    {

        readonly ConstantBuilder _constants;
        BlobBuilder _builder;
        int _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public ElementValuePairTableBuilder(ConstantBuilder constants)
        {
            _constants = constants ?? throw new ArgumentNullException(nameof(constants));
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        BlobBuilder Builder => _builder ??= new BlobBuilder();

        /// <summary>
        /// Adds an element value pair.
        /// </summary>
        public void Add(Utf8ConstantHandle name, BlobBuilder value)
        {
            var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(name.Value);
            Builder.LinkSuffix(value);
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