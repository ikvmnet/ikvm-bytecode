﻿namespace IKVM.ByteCode.Parsing
{

    public sealed record SameStackMapFrameRecord(byte Tag) : StackMapFrameRecord(Tag)
    {

        public static bool TryReadSameStackMapFrame(ref ClassFormatReader reader, byte tag, out StackMapFrameRecord frame)
        {
            frame = new SameStackMapFrameRecord(tag);
            return true;
        }

    }

}
