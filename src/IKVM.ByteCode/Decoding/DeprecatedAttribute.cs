﻿using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct DeprecatedAttribute()
    {

        public static DeprecatedAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out DeprecatedAttribute attribute)
        {
            attribute = new DeprecatedAttribute();
            return true;
        }

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
            encoder.Deprecated(attributeName);
        }

    }

}