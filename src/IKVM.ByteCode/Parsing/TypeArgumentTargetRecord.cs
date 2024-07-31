namespace IKVM.ByteCode.Parsing
{

    public sealed record TypeArgumentTargetRecord(ushort Offset, byte TypeArgumentIndex) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU2(out ushort offset) == false)
                return false;
            if (reader.TryReadU1(out byte typeArgumentIndex) == false)
                return false;

            targetInfo = new TypeArgumentTargetRecord(offset, typeArgumentIndex);
            return true;
        }

    }

}