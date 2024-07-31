namespace IKVM.ByteCode.Parsing
{

    public sealed record FormalParameterTargetRecord(byte ParameterIndex) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU1(out byte parameterIndex) == false)
                return false;

            targetInfo = new FormalParameterTargetRecord(parameterIndex);
            return true;
        }

    }

}