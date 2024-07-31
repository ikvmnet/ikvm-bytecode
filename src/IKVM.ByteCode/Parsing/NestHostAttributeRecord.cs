namespace IKVM.ByteCode.Parsing
{

    public sealed record NestHostAttributeRecord(ClassConstantHandle HostClass) : AttributeRecord
    {

        public static bool TryReadNestHostAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort hostClassIndex) == false)
                return false;

            attribute = new NestHostAttributeRecord(new ClassConstantHandle(hostClassIndex));
            return true;
        }

    }

}
