using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct RecordComponent(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeTable Attributes)
    {

        public static RecordComponent Nil => default;


        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref RecordComponentTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.RecordComponent(map.Map(Name), map.Map(Descriptor), e => self.Attributes.EncodeTo(map, ref e));
        }

    }

}
