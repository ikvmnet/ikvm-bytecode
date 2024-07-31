namespace IKVM.ByteCode.Parsing
{

    public sealed record LocalVariableTargetTableRecord(LocalVariableTargetTableItemRecord[] Items) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var items = new LocalVariableTargetTableItemRecord[length];
            for (int i = 0; i < length; i++)
                if (LocalVariableTargetTableItemRecord.TryRead(ref reader, out items[i]) == false)
                    return false;

            targetInfo = new LocalVariableTargetTableRecord(items);
            return true;
        }

    }

}