using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a stack map table structure.
    /// </summary>
    public struct StackMapTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public StackMapTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Validates the given frame type value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="paramName"></param>
        /// <param name="frameType"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void ValidateFrameType(byte value, byte min, byte max, string paramName, string frameType)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(paramName, $"Invalid frame type value {value} for {frameType}.");
        }

        /// <summary>
        /// Adds a Same Frame.
        /// </summary>
        /// <param name="frameType"></param>
        public StackMapTableEncoder AddSameFrame(byte frameType)
        {
            ValidateFrameType(frameType, 0, 63, nameof(frameType), "SAME");
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(frameType);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Same Locals 1 Stack Item Frame.
        /// </summary>
        /// <param name="frameType"></param>
        public StackMapTableEncoder AddSameLocalsOneStackItemFrame(byte frameType)
        {
            ValidateFrameType(frameType, 64, 127, nameof(frameType), "SAME_LOCALS_1_STACK_ITEM");
            throw new NotImplementedException();
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Same Locals 1 Stack Item Frame Extended.
        /// </summary>
        public StackMapTableEncoder AddSameLocalsOneStackItemFrameExtended()
        {
            throw new NotImplementedException();
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Chop Frame.
        /// </summary>
        public StackMapTableEncoder AddChopFrame(byte frameType)
        {
            ValidateFrameType(frameType, 248, 250, nameof(frameType), "CHOP");
            throw new NotImplementedException();
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Same Frame Extended.
        /// </summary>
        public StackMapTableEncoder AddSameFrameExtended()
        {
            throw new NotImplementedException();
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds an Append Frame.
        /// </summary>
        public StackMapTableEncoder AddAppendFrame(byte frameType)
        {
            ValidateFrameType(frameType, 252, 254, nameof(frameType), "APPEND");
            throw new NotImplementedException();
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Full Frame.
        /// </summary>
        public StackMapTableEncoder AddFullFrame()
        {
            throw new NotImplementedException();
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
