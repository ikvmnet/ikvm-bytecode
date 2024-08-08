using System;
using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct StackMapFrame(byte FrameType, ReadOnlySequence<byte> Data)
    {

        public static explicit operator SameStackMapFrame(StackMapFrame value) => value.AsSameStackMap();

        public static explicit operator SameLocalsOneStackMapFrame(StackMapFrame value) => value.AsSameLocalsOneStackMap();

        public static explicit operator SameLocalsOneExtendedStackMapFrame(StackMapFrame value) => value.AsSameLocalsOneExtendedStackMap();

        public static explicit operator ChopStackMapFrame(StackMapFrame value) => value.AsChopStackMap();

        public static explicit operator SameExtendedStackMapFrame(StackMapFrame value) => value.AsSameExtendedStackMap();

        public static explicit operator AppendStackMapFrame(StackMapFrame value) => value.AsAppendStackMap();

        public static explicit operator FullStackMapFrame(StackMapFrame value) => value.AsFullStackMap();

        /// <summary>
        /// Attempts to measure the size of the element value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U1;
            if (reader.TryReadU1(out byte frameType) == false)
                return false;

            if (TryMeasureData(ref reader, frameType, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the stack map frame value with the given type.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="frameType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        static bool TryMeasureData(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            return frameType switch
            {
                <= 63 => SameStackMapFrame.TryMeasure(ref reader, frameType, ref size),
                >= 64 and <= 127 => SameLocalsOneStackMapFrame.TryMeasure(ref reader, frameType, ref size),
                247 => SameLocalsOneExtendedStackMapFrame.TryMeasure(ref reader, frameType, ref size),
                >= 248 and <= 250 => ChopStackMapFrame.TryMeasure(ref reader, frameType, ref size),
                251 => SameExtendedStackMapFrame.TryMeasure(ref reader, frameType, ref size),
                >= 252 and <= 254 => AppendStackMapFrame.TryMeasure(ref reader, frameType, ref size),
                255 => FullStackMapFrame.TryMeasure(ref reader, frameType, ref size),
                _ => throw new ByteCodeException($"Invalid stack map frame tag value: '{frameType}'.")
            };
        }

        /// <summary>
        /// Attempts to read the data for the element value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="frame"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out StackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU1(out byte frameType) == false)
                return false;

            int size = 0;
            if (TryMeasure(ref reader, ref size) == false)
                return false;

            reader.Rewind(size);
            if (reader.TryReadMany(size, out var data) == false)
                return false;

            frame = new StackMapFrame(frameType, data);
            return true;
        }

        public SameStackMapFrame AsSameStackMap()
        {
            if (FrameType is not <= 63)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a SameStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (SameStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public SameLocalsOneStackMapFrame AsSameLocalsOneStackMap()
        {
            if (FrameType is not >= 64 or not <= 127)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a SameLocalsOneStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (SameLocalsOneStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public SameLocalsOneExtendedStackMapFrame AsSameLocalsOneExtendedStackMap()
        {
            if (FrameType is not 247)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a SameLocalsOneExtendedStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (SameLocalsOneExtendedStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public ChopStackMapFrame AsChopStackMap()
        {
            if (FrameType is not >= 248 or not <= 250)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a ChopStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (ChopStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public SameExtendedStackMapFrame AsSameExtendedStackMap()
        {
            if (FrameType is not 251)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a SameExtendedStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (SameExtendedStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public AppendStackMapFrame AsAppendStackMap()
        {
            if (FrameType is not >= 252 or not <= 254)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a AppendStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (AppendStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public FullStackMapFrame AsFullStackMap()
        {
            if (FrameType is not >= 255)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a FullStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (FullStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

    }

}
