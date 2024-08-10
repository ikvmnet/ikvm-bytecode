using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LineNumberInfo(ushort StartPc, ushort LineNumber)
    {

        public readonly ushort StartPc = StartPc;
        public readonly ushort LineNumber = LineNumber;
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
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref LineNumberTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            encoder.LineNumber(StartPc, LineNumber);
        }

    }

}
