using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes an annnotation structure:
    /// </summary>
    /// <remarks>
    /// annotation {
    ///    u2 type_index;
    ///    u2 num_element_value_pairs;
    ///    {
    ///        u2 element_name_index;
    ///        element_value value;
    ///    }
    ///    element_value_pairs[num_element_value_pairs];
    /// }
    /// </remarks>
    public struct AnnotationEncoder
    {

        readonly BlobBuilder _builder;
        byte _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public AnnotationEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        /// <summary>
        /// Encodes a new annotation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="elementValuePairs"></param>
        /// <returns></returns>
        public void Annotation(Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValuePairs)
        {
            if (elementValuePairs is null)
                throw new ArgumentNullException(nameof(elementValuePairs));
            if (_count > 0)
                throw new InvalidOperationException("Only a single annotation can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(type.Index);
            elementValuePairs(new ElementValuePairTableEncoder(_builder));
            _count++;
        }

    }

}
