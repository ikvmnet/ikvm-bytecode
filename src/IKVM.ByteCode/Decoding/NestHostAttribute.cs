using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct NestHostAttribute(ClassConstantHandle NestHost)
    {

        public static NestHostAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out NestHostAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort hostClassIndex) == false)
                return false;

            attribute = new NestHostAttribute(new ClassConstantHandle(hostClassIndex));
            return true;
        }

        public readonly ClassConstantHandle NestHost = NestHost;
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
            encoder.NestHost(attributeName, map.Map(NestHost));
        }

    }

}
