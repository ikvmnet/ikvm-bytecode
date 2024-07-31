namespace IKVM.ByteCode.Parsing
{

    public sealed record ElementValueClassValueRecord(Utf8ConstantHandle Class) : ElementValueValueRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out ElementValueValueRecord value)
        {
            value = null;

            if (reader.TryReadU2(out ushort classInfoIndex) == false)
                return false;

            value = new ElementValueClassValueRecord(new Utf8ConstantHandle(classInfoIndex));
            return true;
        }

    }

}