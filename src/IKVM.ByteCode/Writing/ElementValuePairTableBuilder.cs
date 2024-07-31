using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes an 'element_value_pair_table' structure.
    /// </summary>
    public struct ElementValuePairTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public ElementValuePairTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds an element value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="elementValue"></param>
        public void Element(Utf8ConstantHandle elementName, Action<ElementValueEncoder> elementValue)
        {
            if (elementValue is null)
                throw new ArgumentNullException(nameof(elementValue));

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(elementName.Index);
            elementValue(new ElementValueEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
        }

    }

}