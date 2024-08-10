using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct SyntheticAttribute()
    {

        public static SyntheticAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SyntheticAttribute attribute)
        {
            attribute = new SyntheticAttribute();
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="attributeName"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            encoder.Synthetic(attributeName);
        }

    }

}
