namespace IKVM.ByteCode.Parsing
{

    public sealed record NullVariableInfoRecord : VerificationTypeInfoRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out VerificationTypeInfoRecord record)
        {
            record = new NullVariableInfoRecord();
            return true;
        }

    }

}
