using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct TypePathComponent(TypePathKind Kind, byte ArgumentIndex)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U1 + ClassFormatReader.U1;
            if (reader.TryAdvance(ClassFormatReader.U1 + ClassFormatReader.U1) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out TypePathComponent record)
        {
            record = default;

            if (reader.TryReadU1(out byte kind) == false)
                return false;
            if (reader.TryReadU1(out byte argumentIndex) == false)
                return false;

            record = new TypePathComponent((TypePathKind)kind, argumentIndex);
            return true;
        }

        public readonly TypePathKind Kind = Kind;
        public readonly byte ArgumentIndex = ArgumentIndex;
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
        public readonly void CopyTo<TConstantMap>(TConstantMap map, ref TypePathEncoder encoder)
            where TConstantMap : IConstantMap
        {
            WriteTo(ref encoder);
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref TypePathEncoder encoder)
        {
            switch (Kind)
            {
                case TypePathKind.TypeArgument:
                    encoder.TypeArgument(ArgumentIndex);
                    break;
                case TypePathKind.InnerType:
                    encoder.InnerType();
                    break;
                case TypePathKind.Array:
                    encoder.Array();
                    break;
                case TypePathKind.Wildcard:
                    encoder.Wildcard();
                    break;
            }
        }

    }

}
