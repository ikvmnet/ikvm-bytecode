namespace IKVM.ByteCode.Parsing
{

    public record SourceFileAttributeRecord(Utf8ConstantHandle SourceFile) : AttributeRecord
    {

        public static bool TryReadSourceFileAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort sourceFileIndex) == false)
                return false;

            attribute = new SourceFileAttributeRecord(new Utf8ConstantHandle(sourceFileIndex));
            return true;
        }

    }

}