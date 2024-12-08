using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct Annotation(Utf8ConstantHandle Type, ElementValuePairTable Elements)
    {

        /// <summary>
        /// Attempts to measure the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            if (ElementValuePairTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="annotation"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out Annotation annotation)
        {
            annotation = default;

            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (ElementValuePairTable.TryRead(ref reader, out var elements) == false)
                return false;

            annotation = new Annotation(new(typeIndex), elements);
            return true;
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantMap>(TConstantMap map, ref AnnotationEncoder encoder)
            where TConstantMap : IConstantMap
        {
            var self = this;
            encoder.Annotation(map.Map(Type), e => self.Elements.EncodeTo(map, ref e));
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref AnnotationEncoder encoder)
        {
            var self = this;
            encoder.Annotation(Type, e => self.Elements.WriteTo(ref e));
        }

        readonly bool _isNotNil = true;

        public readonly Utf8ConstantHandle Type = Type;
        public readonly ElementValuePairTable Elements = Elements;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
