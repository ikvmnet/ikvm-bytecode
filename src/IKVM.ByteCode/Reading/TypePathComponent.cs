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

    }

}
