namespace IKVM.ByteCode.Parsing
{

    public sealed record EnclosingMethodAttributeRecord(ClassConstantHandle Class, NameAndTypeConstantHandle Method) : AttributeRecord
    {

        public static bool TryReadEnclosingMethodAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort methodIndex) == false)
                return false;

            attribute = new EnclosingMethodAttributeRecord(new(classIndex), new(methodIndex));
            return true;
        }

    }

}
