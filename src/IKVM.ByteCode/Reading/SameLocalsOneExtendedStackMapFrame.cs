namespace IKVM.ByteCode.Reading
{

    public readonly record struct SameLocalsOneExtendedStackMapFrame(byte FrameType, ushort OffsetDelta, VerificationTypeInfo Stack)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out SameLocalsOneExtendedStackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU2(out ushort offsetDelta) == false)
                return false;
            if (VerificationTypeInfo.TryRead(ref reader, out var verificationTypeInfo) == false)
                return false;

            frame = new SameLocalsOneExtendedStackMapFrame(frameType, offsetDelta, verificationTypeInfo);
            return true;
        }

    }

}
