namespace IKVM.ByteCode.Parsing
{

    public sealed record ObjectVariableInfoRecord(ClassConstantHandle Class) : VerificationTypeInfoRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out VerificationTypeInfoRecord record)
        {
            record = null;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;

            record = new ObjectVariableInfoRecord(new ClassConstantHandle(classIndex));
            return true;
        }

    }

}
