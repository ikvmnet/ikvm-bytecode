namespace IKVM.ByteCode.Reading
{

    public readonly record struct LineNumberTableAttribute(LineNumberTable LineNumbers)
    {

        public static LineNumberTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out LineNumberTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort itemCount) == false)
                return false;

            var items = itemCount == 0 ? [] : new LineNumberInfo[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                if (reader.TryReadU2(out ushort codeOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort lineNumber) == false)
                    return false;

                items[i] = new LineNumberInfo(codeOffset, lineNumber);
            }

            attribute = new LineNumberTableAttribute(new(items));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
