namespace IKVM.ByteCode.Parsing
{

    public sealed record UninitializedThisVariableInfoRecord : VerificationTypeInfoRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out VerificationTypeInfoRecord record)
        {
            record = new UninitializedThisVariableInfoRecord();
            return true;
        }

    }

}
