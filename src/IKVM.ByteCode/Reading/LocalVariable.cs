using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariable(ushort StartPc, ushort Length, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, ushort Slot)
    {

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref LocalVariableTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            encoder.LocalVariable(StartPc, Length, map.Map(Name), map.Map(Descriptor), Slot);
        }

    }

}
