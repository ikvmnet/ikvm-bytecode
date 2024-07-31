namespace IKVM.ByteCode.Parsing
{

    public sealed record IntegerVariableInfoRecord : VerificationTypeInfoRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out VerificationTypeInfoRecord record)
        {
            record = new IntegerVariableInfoRecord();
            return true;
        }

    }

}
