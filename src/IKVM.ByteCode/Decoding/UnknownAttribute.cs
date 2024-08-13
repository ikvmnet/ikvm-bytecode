using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct UnknownAttribute(ReadOnlySequence<byte> Data)
    {

        public static bool TryRead(ref ClassFormatReader reader, out UnknownAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadMany(reader.Remaining, out var data) == false)
                return false;

            attribute = new UnknownAttribute(data);
            return true;
        }

        public readonly ReadOnlySequence<byte> Data = Data;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
