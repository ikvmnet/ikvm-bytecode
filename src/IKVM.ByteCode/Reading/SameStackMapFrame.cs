namespace IKVM.ByteCode.Reading
{

    public readonly record struct SameStackMapFrame(byte FrameType)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out SameStackMapFrame frame)
        {
            frame = new SameStackMapFrame(frameType);
            return true;
        }

    }

}
