using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct SourceDebugExtensionAttribute(ReadOnlySequence<byte> Data, bool IsNotNil = true)
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

        public bool IsNil => !IsNotNil;

    }

}
