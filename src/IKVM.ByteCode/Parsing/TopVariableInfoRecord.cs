namespace IKVM.ByteCode.Parsing
{

    public sealed record TopVariableInfoRecord : VerificationTypeInfoRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out VerificationTypeInfoRecord record)
        {
            record = new TopVariableInfoRecord();
            return true;
        }

    }

}
