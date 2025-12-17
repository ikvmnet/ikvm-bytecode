using System;
using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
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

            int size = 0;
            if (TryMeasure(ref reader, ref size) == false)
                return false;

            // rewind to before measured
            reader.Rewind(size);

            // read frame type
            if (reader.TryReadU1(out byte frameType) == false)
                return false;

            // read data, which is size -1 (for frametype)
            if (reader.TryReadMany(size - 1, out var data) == false)
                return false;

            frame = new StackMapFrame(frameType, data);
            return true;
        }

        public readonly byte FrameType = FrameType;
        public readonly ReadOnlySequence<byte> Data = Data;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        public readonly SameStackMapFrame AsSameStackMap()
        {
            if (FrameType is not <= 63)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a SameStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (SameStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public readonly SameLocalsOneStackMapFrame AsSameLocalsOneStackMap()
        {
            if (FrameType is not >= 64 or not <= 127)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a SameLocalsOneStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (SameLocalsOneStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public readonly SameLocalsOneExtendedStackMapFrame AsSameLocalsOneExtendedStackMap()
        {
            if (FrameType is not 247)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a SameLocalsOneExtendedStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (SameLocalsOneExtendedStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public readonly ChopStackMapFrame AsChopStackMap()
        {
            if (FrameType is not >= 248 or not <= 250)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a ChopStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (ChopStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public readonly SameExtendedStackMapFrame AsSameExtendedStackMap()
        {
            if (FrameType is not 251)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a SameExtendedStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (SameExtendedStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public readonly AppendStackMapFrame AsAppendStackMap()
        {
            if (FrameType is not >= 252 or not <= 254)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a AppendStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (AppendStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        public readonly FullStackMapFrame AsFullStackMap()
        {
            if (FrameType is not >= 255)
                throw new ByteCodeException($"StackMapFrame with FrameType {FrameType} is not a FullStackMapFrame.");

            var reader = new ClassFormatReader(Data);
            if (FullStackMapFrame.TryRead(ref reader, FrameType, out var frame) == false)
                throw new InvalidClassException("End of data reached while parsing stack map frame data.");

            return frame;
        }

        /// <summary>
        /// Copies this frame to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        /// <exception cref="ByteCodeException"></exception>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref StackMapTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            if (FrameType is <= 65)
                ((SameStackMapFrame)this).CopyTo(constantView, constantPool, ref encoder);
            else if (FrameType is >= 64 and <= 127)
                ((SameLocalsOneStackMapFrame)this).CopyTo(constantView, constantPool, ref encoder);
            else if (FrameType is 247)
                ((SameLocalsOneExtendedStackMapFrame)this).CopyTo(constantView, constantPool, ref encoder);
            else if (FrameType is >= 248 and <= 250)
                ((ChopStackMapFrame)this).CopyTo(constantView, constantPool, ref encoder);
            else if (FrameType is 251)
                ((SameExtendedStackMapFrame)this).CopyTo(constantView, constantPool, ref encoder);
            else if (FrameType is >= 252 and <= 254)
                ((AppendStackMapFrame)this).CopyTo(constantView, constantPool, ref encoder);
            else if (FrameType is 255)
                ((FullStackMapFrame)this).CopyTo(constantView, constantPool, ref encoder);
            else
                throw new ByteCodeException("Invalid stack map frame type.");
        }

    }

}
