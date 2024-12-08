using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct SignatureAttribute(Utf8ConstantHandle Signature)
    {

        public static SignatureAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SignatureAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort signatureIndex) == false)
                return false;

            attribute = new SignatureAttribute(new Utf8ConstantHandle(signatureIndex));
            return true;
        }

        public readonly Utf8ConstantHandle Signature = Signature;
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
            encoder.Signature(attributeName, map.Map(Signature));
        }

    }

}