namespace IKVM.ByteCode.Parsing
{

    public sealed record SuperTypeTargetRecord(ushort SuperTypeIndex) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU2(out ushort superTypeIndex) == false)
                return false;

            targetInfo = new SuperTypeTargetRecord(superTypeIndex);
            return true;
        }

    }

}