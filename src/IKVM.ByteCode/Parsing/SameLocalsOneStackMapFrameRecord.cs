namespace IKVM.ByteCode.Parsing
{

    public sealed record SameLocalsOneStackMapFrameRecord(byte FrameType, VerificationTypeInfoRecord Stack) : StackMapFrameRecord(FrameType)
    {

        public static bool TryReadSameLocalsOneStackItemStackMapFrame(ref ClassFormatReader reader, byte tag, out StackMapFrameRecord frame)
        {
            frame = null;

            if (VerificationTypeInfoRecord.TryReadVerificationTypeInfo(ref reader, out var stack) == false)
                return false;

            frame = new SameLocalsOneStackMapFrameRecord(tag, stack);
            return true;
        }

    }

}
