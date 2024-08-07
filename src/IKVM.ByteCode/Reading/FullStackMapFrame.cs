using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct FullStackMapFrame(byte FrameType, ushort OffsetDelta, ReadOnlyMemory<VerificationTypeInfo> Locals, ReadOnlyMemory<VerificationTypeInfo> Stack)
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

            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out var localsCount) == false)
                return false;

            for (var i = 0; i < localsCount; i++)
                if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                    return false;

            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out var stackCount) == false)
                return false;

            for (var i = 0; i < stackCount; i++)
                if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte tag, out FullStackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU2(out ushort offsetDelta) == false)
                return false;
            if (reader.TryReadU2(out ushort localsCount) == false)
                return false;

            var locals = new VerificationTypeInfo[localsCount];
            for (int i = 0; i < localsCount; i++)
                if (VerificationTypeInfo.TryRead(ref reader, out locals[i]) == false)
                    return false;

            if (reader.TryReadU2(out ushort stackCount) == false)
                return false;

            var stack = new VerificationTypeInfo[stackCount];
            for (int i = 0; i < stackCount; i++)
                if (VerificationTypeInfo.TryRead(ref reader, out stack[i]) == false)
                    return false;

            frame = new FullStackMapFrame(tag, offsetDelta, locals, stack);
            return true;
        }

    }

}
