namespace IKVM.ByteCode.Reading
{

    public readonly record struct TypePathItem(TypePathKind Kind, byte ArgumentIndex)
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypePathItem record)
        {
            record = default;

            if (reader.TryReadU1(out byte kind) == false)
                return false;
            if (reader.TryReadU1(out byte argumentIndex) == false)
                return false;

            record = new TypePathItem((TypePathKind)kind, argumentIndex);
            return true;
        }

    }

}
