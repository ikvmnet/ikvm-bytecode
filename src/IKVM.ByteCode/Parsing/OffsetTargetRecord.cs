namespace IKVM.ByteCode.Parsing
{

    public sealed record OffsetTargetRecord(ushort Offset) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU2(out ushort offset) == false)
                return false;

            targetInfo = new CatchTargetRecord(offset);
            return true;
        }

    }

}