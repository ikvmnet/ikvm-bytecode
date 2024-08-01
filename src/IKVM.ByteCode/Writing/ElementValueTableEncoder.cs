using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes an 'element_value_table' structure.
    /// </summary>
    public struct ElementValueTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public ElementValueTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Encodes an existing set of elements.
        /// </summary>
        /// <param name="elements"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Encode(ReadOnlySpan<ElementValueRecord> elements)
        {
            foreach (var i in elements)
                Element(e => e.Encode(i));
        }

        /// <summary>
        /// Adds an element value pair.
        /// </summary>
        /// <param name="value"></param>
        public void Element(Action<ElementValueEncoder> value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            value(new ElementValueEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
        }

    }

}