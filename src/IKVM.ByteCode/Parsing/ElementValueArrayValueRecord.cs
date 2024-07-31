namespace IKVM.ByteCode.Parsing
{

    public sealed record ElementValueArrayValueRecord(ElementValueRecord[] Values) : ElementValueValueRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out ElementValueValueRecord value)
        {
            value = null;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var values = new ElementValueRecord[length];
            for (int i = 0; i < length; i++)
            {
                if (ElementValueRecord.TryRead(ref reader, out var j) == false)
                    return false;

                values[i] = j;
            }

            value = new ElementValueArrayValueRecord(values);
            return true;
        }

    }


}
