﻿using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct PermittedSubclassesAttribute(ClassConstantHandleTable PermittedSubclasses)
    {

        public static PermittedSubclassesAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out PermittedSubclassesAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var classes = count == 0 ? [] : new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort classIndex) == false)
                    return false;

                classes[i] = new(classIndex);
            }

            attribute = new PermittedSubclassesAttribute(new(classes));
            return true;
        }

        public readonly ClassConstantHandleTable PermittedSubclasses = PermittedSubclasses;
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
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.PermittedSubclasses(attributeName, e => self.EncodeTo(map, ref e));
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="builder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref ClassConstantTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            PermittedSubclasses.EncodeTo(map, ref encoder);
        }

    }

}