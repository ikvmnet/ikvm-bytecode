namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVarTargetItem(ushort Start, ushort Length, ushort Index)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out LocalVarTargetItem record)
        {
            record = default;

            if (reader.TryReadU2(out ushort start) == false)
                return false;
            if (reader.TryReadU2(out ushort length) == false)
                return false;
            if (reader.TryReadU2(out ushort index) == false)
                return false;

            record = new LocalVarTargetItem(start, length, index);
            return true;
        }

    }

}
