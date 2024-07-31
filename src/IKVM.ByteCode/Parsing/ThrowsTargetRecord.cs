namespace IKVM.ByteCode.Parsing
{

    public sealed record ThrowsTargetRecord(ushort ThrowsTypeIndex) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU2(out ushort throwsTypeIndex) == false)
                return false;

            targetInfo = new ThrowsTargetRecord(throwsTypeIndex);
            return true;
        }

    }

}