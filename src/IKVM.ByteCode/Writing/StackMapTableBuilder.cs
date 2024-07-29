using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides support in building a frame table structure for the StackMapTable attribute.
    /// </summary>
    public class StackMapTableBuilder
    {

        readonly ConstantBuilder _constants;
        BlobBuilder _builder;
        int _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public StackMapTableBuilder(ConstantBuilder constants)
        {
            _constants = constants ?? throw new ArgumentNullException(nameof(constants));
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        BlobBuilder Builder => _builder ??= new BlobBuilder();

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
        public void AddSameFrame(byte frameType)
        {
            ValidateFrameType(frameType, 0, 63, nameof(frameType), "SAME");
            var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(frameType);
            _count++;
        }

        /// <summary>
        /// Adds a Same Locals 1 Stack Item Frame.
        /// </summary>
        /// <param name="frameType"></param>
        public void AddSameLocalsOneStackItemFrame(byte frameType)
        {
            ValidateFrameType(frameType, 64, 127, nameof(frameType), "SAME_LOCALS_1_STACK_ITEM");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a Same Locals 1 Stack Item Frame Extended.
        /// </summary>
        public void AddSameLocalsOneStackItemFrameExtended()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a Chop Frame.
        /// </summary>
        public void AddChopFrame(byte frameType)
        {
            ValidateFrameType(frameType, 248, 250, nameof(frameType), "CHOP");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a Same Frame Extended.
        /// </summary>
        public void AddSameFrameExtended()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an Append Frame.
        /// </summary>
        public void AddAppendFrame(byte frameType)
        {
            ValidateFrameType(frameType, 252, 254, nameof(frameType), "APPEND");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a Full Frame.
        /// </summary>
        public void AddFullFrame()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes the stack map table.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2((ushort)_count);
            if (_builder != null)
                builder.LinkSuffix(_builder);
        }

    }

}
