using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct StackMapTableAttribute(ReadOnlyMemory<StackMapFrame> Frames, bool IsNotNil = true)
    {

        public static StackMapTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out StackMapTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var frames = new StackMapFrame[count];
            for (int i = 0; i < count; i++)
                if (StackMapFrame.TryRead(ref reader, out frames[i]) == false)
                    return false;

            attribute = new StackMapTableAttribute(frames);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
