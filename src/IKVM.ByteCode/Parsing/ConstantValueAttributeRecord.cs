namespace IKVM.ByteCode.Parsing
{

    public sealed record ConstantValueAttributeRecord(ConstantHandle Handle) : AttributeRecord
    {

        public static bool TryReadConstantValueAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort handleIndex) == false)
                return false;

            attribute = new ConstantValueAttributeRecord(new ConstantHandle(handleIndex));
            return true;
        }

    }

}
