namespace IKVM.ByteCode.Parsing
{

    public sealed record ElementValueEnumConstantValueRecord(Utf8ConstantHandle TypeName, Utf8ConstantHandle ConstantName) : ElementValueValueRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out ElementValueValueRecord value)
        {
            value = null;

            if (reader.TryReadU2(out ushort typeNameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort constantNameIndex) == false)
                return false;

            value = new ElementValueEnumConstantValueRecord(new(typeNameIndex), new(constantNameIndex));
            return true;
        }

    }

}
