using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct StackMapTableAttribute(StackMapFrameTable Frames)
    {

        public static StackMapTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out StackMapTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var frames = count == 0 ? [] : new StackMapFrame[count];
            for (int i = 0; i < count; i++)
                if (StackMapFrame.TryRead(ref reader, out frames[i]) == false)
                    return false;

            attribute = new StackMapTableAttribute(new(frames));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
