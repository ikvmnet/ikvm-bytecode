﻿using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct RuntimeInvisibleTypeAnnotationsAttribute(TypeAnnotationTable TypeAnnotations)
    {

        public static RuntimeInvisibleTypeAnnotationsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeInvisibleTypeAnnotationsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var annotations = count == 0 ? [] : new TypeAnnotation[count];
            for (int i = 0; i < count; i++)
            {
                if (TypeAnnotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                annotations[i] = annotation;
            }

            attribute = new RuntimeInvisibleTypeAnnotationsAttribute(new(annotations));
            return true;
        }

        public readonly TypeAnnotationTable TypeAnnotations = TypeAnnotations;
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
        /// <param name="attributeName"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantMap>(TConstantMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            var self = this;
            encoder.RuntimeInvisibleTypeAnnotations(attributeName, e => self.TypeAnnotations.EncodeTo(map, ref e));
        }

    }

}
