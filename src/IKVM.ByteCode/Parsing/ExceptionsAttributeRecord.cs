namespace IKVM.ByteCode.Parsing
{

    public sealed record ExceptionsAttributeRecord(ClassConstantHandle[] Exceptions) : AttributeRecord
    {

        public static bool TryReadExceptionsAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var entries = new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort index) == false)
                    return false;

                entries[i] = new(index);
            }

            attribute = new ExceptionsAttributeRecord(entries);
            return true;
        }

    }

}