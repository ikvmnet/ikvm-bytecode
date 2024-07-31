namespace IKVM.ByteCode.Parsing
{

    public sealed record NestMembersAttributeRecord(ClassConstantHandle[] ClassIndexes) : AttributeRecord
    {

        public static bool TryReadNestMembersAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var classes = new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort classIndex) == false)
                    return false;

                classes[i] = new (classIndex);
            }

            attribute = new NestMembersAttributeRecord(classes);
            return true;
        }

    }

}
