using System;
using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct SourceFileAttribute(Utf8ConstantHandle SourceFile)
    {

        public static SourceFileAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SourceFileAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort sourceFileIndex) == false)
                return false;

            attribute = new SourceFileAttribute(new Utf8ConstantHandle(sourceFileIndex));
            return true;
        }

        public readonly Utf8ConstantHandle SourceFile = SourceFile;
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
        /// <param name="encoder"></param>
        public void EncodeTo<TConstantMap>(TConstantMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            encoder.SourceFile(attributeName, map.Map(SourceFile));
        }

    }

}