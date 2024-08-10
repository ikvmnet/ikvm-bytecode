using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariableType(ushort StartPc, ushort Length, Utf8ConstantHandle Name, Utf8ConstantHandle Signature, ushort Slot)
    {

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref LocalVariableTypeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            encoder.LocalVariableType(StartPc, Length, map.Map(Name), map.Map(Signature), Slot);
        }

    }

}
