using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct TypePathComponent(TypePathKind Kind, byte ArgumentIndex)
    {

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
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref TypePathEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
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
