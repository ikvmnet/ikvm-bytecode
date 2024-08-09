using System;

using IKVM.ByteCode.Buffers;

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
        public StackMapTableEncoder Same(byte frameType)
        {
            ValidateFrameType(frameType, 0, 63, nameof(frameType), "SAME");
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.WriteU1(frameType);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Same Locals 1 Stack Item Frame.
        /// </summary>
        /// <param name="frameType"></param>
        public StackMapTableEncoder SameLocalsOneStackItem(byte frameType, Action<VerificationTypeInfoEncoder> stack)
        {
            ValidateFrameType(frameType, 64, 127, nameof(frameType), "SAME_LOCALS_1_STACK_ITEM");
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.WriteU1(frameType);
            stack(new VerificationTypeInfoEncoder(_builder, 1));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Same Locals 1 Stack Item Frame Extended.
        /// </summary>
        public StackMapTableEncoder SameLocalsOneStackItemExtended(ushort offsetDelta, Action<VerificationTypeInfoEncoder> stack)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1(247);
            w.WriteU2(offsetDelta);
            stack(new VerificationTypeInfoEncoder(_builder, 1));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Chop Frame.
        /// </summary>
        public StackMapTableEncoder Chop(byte frameType, ushort offsetDelta)
        {
            ValidateFrameType(frameType, 248, 250, nameof(frameType), "CHOP");
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1(247);
            w.WriteU2(offsetDelta);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Same Frame Extended.
        /// </summary>
        public StackMapTableEncoder SameExtended(ushort offsetDelta)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1(251);
            w.WriteU2(offsetDelta);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds an Append Frame.
        /// </summary>
        public StackMapTableEncoder Append(byte frameType, ushort offsetDelta, Action<VerificationTypeInfoEncoder> locals)
        {
            ValidateFrameType(frameType, 252, 254, nameof(frameType), "APPEND");
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1(frameType);
            w.WriteU2(offsetDelta);
            locals(new VerificationTypeInfoEncoder(_builder, (ushort)(frameType - 251)));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a Full Frame.
        /// </summary>
        public StackMapTableEncoder Full(ushort offsetDelta, Action<VerificationTypeInfoEncoder> locals, Action<VerificationTypeInfoEncoder> stack)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1(255);
            w.WriteU2(offsetDelta);
            locals(new VerificationTypeInfoEncoder(_builder));
            stack(new VerificationTypeInfoEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

    }

}
