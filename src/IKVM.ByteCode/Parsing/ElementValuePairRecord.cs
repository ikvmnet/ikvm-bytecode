namespace IKVM.ByteCode.Parsing
{

    public readonly record struct ElementValuePairRecord(Utf8ConstantHandle Name, ElementValueRecord Value)
    {

        public static bool TryRead(ref ClassFormatReader reader, out ElementValuePairRecord record)
        {
            record = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (ElementValueRecord.TryRead(ref reader, out var elementValue) == false)
                return false;

            record = new ElementValuePairRecord(new(nameIndex), elementValue);
            return true;
        }

    }

}
