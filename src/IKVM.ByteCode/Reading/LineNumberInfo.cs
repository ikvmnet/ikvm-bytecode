using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LineNumberInfo(ushort StartPc, ushort LineNumber)
    {

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
