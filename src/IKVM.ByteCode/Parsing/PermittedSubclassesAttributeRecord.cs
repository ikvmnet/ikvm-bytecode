namespace IKVM.ByteCode.Parsing
{

    internal sealed record PermittedSubclassesAttributeRecord(ClassConstantHandle[] ClassIndexes) : AttributeRecord
    {

        public static bool TryReadPermittedSubclassesAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var classes = new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort classIndex) == false)
                    return false;

                classes[i] = new(classIndex);
            }

            attribute = new PermittedSubclassesAttributeRecord(classes);
            return true;
        }

    }

}
