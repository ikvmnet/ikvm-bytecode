using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct AppendStackMapFrame(byte FrameType, ushort OffsetDelta, ReadOnlyMemory<VerificationTypeInfo> Locals)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="frameType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            for (int i = 0; i < frameType - 251; i++)
                if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out AppendStackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU2(out ushort offsetDelta) == false)
                return false;

            var locals = new VerificationTypeInfo[frameType - 251];
            for (int i = 0; i < frameType - 251; i++)
            {
                if (VerificationTypeInfo.TryRead(ref reader, out var local) == false)
                    return false;

                locals[i] = local;
            }

            frame = new AppendStackMapFrame(frameType, offsetDelta, locals);
            return true;
        }

    }

}
