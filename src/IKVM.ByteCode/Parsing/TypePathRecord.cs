namespace IKVM.ByteCode.Parsing
{

    public readonly record struct TypePathRecord(params TypePathItemRecord[] Path)
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypePathRecord typePath)
        {
            typePath = default;

            if (reader.TryReadU1(out byte length) == false)
                return false;

            var path = new TypePathItemRecord[length];
            for (int i = 0; i < length; i++)
            {
                if (TypePathItemRecord.TryRead(ref reader, out var item) == false)
                    return false;

                path[i] = item;
            }

            typePath = new TypePathRecord(path);
            return true;
        }

    }

}
