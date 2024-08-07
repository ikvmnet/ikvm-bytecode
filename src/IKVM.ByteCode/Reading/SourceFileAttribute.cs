namespace IKVM.ByteCode.Reading
{

    public readonly record struct SourceFileAttribute(Utf8ConstantHandle SourceFile, bool IsNotNil = true)
    {

        public static SourceFileAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SourceFileAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort sourceFileIndex) == false)
                return false;

            attribute = new SourceFileAttribute(new Utf8ConstantHandle(sourceFileIndex));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}