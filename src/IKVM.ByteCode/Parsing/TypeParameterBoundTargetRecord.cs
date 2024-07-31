namespace IKVM.ByteCode.Parsing
{

    public sealed record TypeParameterBoundTargetRecord(byte ParameterIndex, byte BoundIndex) : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = null;

            if (reader.TryReadU1(out byte parameterIndex) == false)
                return false;
            if (reader.TryReadU1(out byte boundIndex) == false)
                return false;

            targetInfo = new TypeParameterBoundTargetRecord(parameterIndex, boundIndex);
            return true;
        }

    }

}
