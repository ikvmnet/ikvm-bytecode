namespace IKVM.ByteCode.Parsing
{

    public sealed record ConstantValueAttributeRecord(ConstantHandle Value) : AttributeRecord
    {

        public static bool TryReadConstantValueAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort valueIndex) == false)
                return false;

            attribute = new ConstantValueAttributeRecord(new ConstantHandle(valueIndex));
            return true;
        }

    }

}
