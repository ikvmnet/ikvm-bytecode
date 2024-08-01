namespace IKVM.ByteCode.Parsing
{

    public readonly record struct LocalVariableTargetTableItemRecord(ushort Offset, ushort Length, ushort Index)
    {

        public static bool TryRead(ref ClassFormatReader reader, out LocalVariableTargetTableItemRecord record)
        {
            record = default;

            if (reader.TryReadU2(out ushort offset) == false)
                return false;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            if (reader.TryReadU2(out ushort index) == false)
                return false;

            record = new LocalVariableTargetTableItemRecord(offset, length, index);
            return true;
        }

    }

}
