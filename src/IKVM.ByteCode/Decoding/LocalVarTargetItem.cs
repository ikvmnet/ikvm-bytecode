using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LocalVarTargetItem(ushort Start, ushort Length, ushort Index)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out LocalVarTargetItem record)
        {
            record = default;

            if (reader.TryReadU2(out ushort start) == false)
                return false;
            if (reader.TryReadU2(out ushort length) == false)
                return false;
            if (reader.TryReadU2(out ushort index) == false)
                return false;

            record = new LocalVarTargetItem(start, length, index);
            return true;
        }

        public readonly ushort Start = Start;
        public readonly ushort Length = Length;
        public readonly ushort Index = Index;
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
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref LocalVarTargetTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            WriteTo(ref encoder);
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref LocalVarTargetTableEncoder encoder)
        {
            encoder.LocalVar(Start, Length, Index);
        }

    }

}
