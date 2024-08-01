namespace IKVM.ByteCode.Parsing
{

    public readonly record struct LocalVariableTargetTableItemRecord(ushort Start, ushort Length, ushort Index)
    {

        public static bool TryRead(ref ClassFormatReader reader, out LocalVariableTargetTableItemRecord record)
        {
            record = default;

            if (reader.TryReadU2(out ushort start) == false)
                return false;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            if (reader.TryReadU2(out ushort index) == false)
                return false;

            record = new LocalVariableTargetTableItemRecord(start, length, index);
            return true;
        }

    }

}
