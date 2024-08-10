using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct SourceDebugExtensionAttribute(ReadOnlySequence<byte> Data)
    {

        public static SourceDebugExtensionAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SourceDebugExtensionAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadMany(reader.Length, out var data) == false)
                return false;

            attribute = new SourceDebugExtensionAttribute(data);
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
        public void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var b = new BlobBuilder();
            Data.CopyTo(b.ReserveBytes((int)Data.Length).GetBytes().AsSpan());
            encoder.SourceDebugExtension(attributeName, b);
        }

    }

}
