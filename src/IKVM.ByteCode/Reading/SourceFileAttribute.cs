namespace IKVM.ByteCode.Reading
{

    public readonly record struct SourceFileAttribute(Utf8ConstantHandle SourceFile)
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

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}