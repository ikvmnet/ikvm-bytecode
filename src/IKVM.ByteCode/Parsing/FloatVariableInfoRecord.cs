namespace IKVM.ByteCode.Parsing
{

    public sealed record FloatVariableInfoRecord : VerificationTypeInfoRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out VerificationTypeInfoRecord record)
        {
            record = new FloatVariableInfoRecord();
            return true;
        }

    }

}
