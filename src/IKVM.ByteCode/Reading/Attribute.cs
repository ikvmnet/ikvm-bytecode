﻿using System;
using System.Buffers;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly partial struct Attribute(Utf8ConstantHandle Name, ReadOnlySequence<byte> Data)
    {

        public static Attribute Nil => default;

        /// <summary>
        /// Parses an attribute.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attribute"></param>
        public static bool TryRead(ref ClassFormatReader reader, out Attribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (reader.TryReadU4(out uint length) == false)
                return false;
            if (reader.TryReadMany(length, out var data) == false)
                return false;

            attribute = new Attribute(new(nameIndex), data);
            return true;
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets the name of the attribute.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

        /// <summary>
        /// Gets the backing data of the attribute.
        /// </summary>
        public readonly ReadOnlySequence<byte> Data = Data;

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
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref AttributeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            EncodeSelfTo(map, ref encoder);
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref AttributeTableEncoder encoder)
        {
            encoder.Attribute(Name, Data);
        }

    }

}
