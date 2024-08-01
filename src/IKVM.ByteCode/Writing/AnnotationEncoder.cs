using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct AnnotationEncoder
    {

        readonly BlobBuilder _builder;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="prev"></param>
        public AnnotationEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        /// <summary>
        /// Encodes an existing annotation.
        /// </summary>
        /// <param name="annotation"></param>
        public void Encode(AnnotationRecord annotation)
        {
            Encode(annotation.Type, e => e.Encode(annotation.Elements));
        }

        /// <summary>
        /// Encodes a new element_value_pair.
        /// </summary>
        /// <param name="elementValuePairs"></param>
        /// <returns></returns>
        public void Encode(Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValuePairs)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(type.Index);
            elementValuePairs(new ElementValuePairTableEncoder(_builder));
        }
    }

}
