namespace IKVM.ByteCode.Parsing
{

    public sealed record TypeParameterTargetRecord(byte ParameterIndex) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader,  out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU1(out byte parameterIndex) == false)
                return false;

            targetInfo = new TypeParameterTargetRecord( parameterIndex);
            return true;
        }

    }

}