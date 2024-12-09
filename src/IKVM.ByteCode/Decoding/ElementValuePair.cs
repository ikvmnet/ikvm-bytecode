using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ElementValuePair(Utf8ConstantHandle Name, ElementValue Value)
    {

        /// <summary>
        /// Measures the size of the current element value pair.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            if (ElementValue.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attemps to read an element value pair.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out ElementValuePair pair)
        {
            pair = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (ElementValue.TryRead(ref reader, out var value) == false)
                return false;

            pair = new ElementValuePair(new(nameIndex), value);
            return true;
        }

        public readonly Utf8ConstantHandle Name = Name;
        public readonly ElementValue Value = Value;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantMap>(TConstantMap map, ref ElementValuePairTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            var self = this;
            encoder.Element(map.Map(Name), e => self.Value.CopyTo(map, ref e));
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref ElementValuePairTableEncoder encoder)
        {
            var self = this;
            encoder.Element(Name, e => self.Value.WriteTo(ref e));
        }

    }

}
