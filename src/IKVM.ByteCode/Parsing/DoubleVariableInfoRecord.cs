namespace IKVM.ByteCode.Parsing
{

    public sealed record DoubleVariableInfoRecord : VerificationTypeInfoRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out VerificationTypeInfoRecord record)
        {
            record = new DoubleVariableInfoRecord();
            return true;
        }

    }

}
