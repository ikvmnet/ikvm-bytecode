namespace IKVM.ByteCode.Parsing
{

    public record struct TypePathItemRecord(TypePathKind Kind, byte ArgumentIndex)
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypePathItemRecord record)
        {
            record = default;

            if (reader.TryReadU1(out byte kind) == false)
                return false;
            if (reader.TryReadU1(out byte argumentIndex) == false)
                return false;

            record = new TypePathItemRecord((TypePathKind)kind, argumentIndex);
            return true;
        }

    }

}
