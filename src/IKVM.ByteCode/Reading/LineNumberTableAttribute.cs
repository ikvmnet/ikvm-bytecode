namespace IKVM.ByteCode.Reading
{

    public readonly record struct LineNumberTableAttribute(LineNumberTable Table, bool IsNotNil = true)
    {

        public static LineNumberTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out LineNumberTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort itemCount) == false)
                return false;

            var items = itemCount == 0 ? [] : new LineNumber[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                if (reader.TryReadU2(out ushort codeOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort lineNumber) == false)
                    return false;

                items[i] = new LineNumber(codeOffset, lineNumber);
            }

            attribute = new LineNumberTableAttribute(new(items));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
