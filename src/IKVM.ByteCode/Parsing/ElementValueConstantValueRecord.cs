namespace IKVM.ByteCode.Parsing
{

    public sealed record ElementValueConstantValueRecord(ConstantHandle Handle) : ElementValueValueRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out ElementValueValueRecord value)
        {
            value = null;

            if (reader.TryReadU2(out ushort index) == false)
                return false;

            value = new ElementValueConstantValueRecord(new ConstantHandle(index));
            return true;
        }

    }

}
