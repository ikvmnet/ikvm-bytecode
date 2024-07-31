namespace IKVM.ByteCode.Parsing
{

    public sealed record CatchTargetRecord(ushort ExceptionTableIndex) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU2(out ushort exceptionTableIndex) == false)
                return false;

            targetInfo = new CatchTargetRecord(exceptionTableIndex);
            return true;
        }

    }

}