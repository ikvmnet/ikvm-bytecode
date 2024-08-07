using System.Buffers;

namespace IKVM.ByteCode.Reading
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

    }

}
