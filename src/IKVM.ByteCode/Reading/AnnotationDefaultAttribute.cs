﻿using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct AnnotationDefaultAttribute(ElementValue DefaultValue)
    {

        public static AnnotationDefaultAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out AnnotationDefaultAttribute attribute)
        {
            attribute = default;

            if (ElementValue.TryRead(ref reader, out var defaultValue) == false)
                return false;

            attribute = new AnnotationDefaultAttribute(defaultValue);
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
            var self = this;
            encoder.AnnotationDefault(attributeName, e => self.DefaultValue.EncodeTo(map, ref e));
        }

    }

}
