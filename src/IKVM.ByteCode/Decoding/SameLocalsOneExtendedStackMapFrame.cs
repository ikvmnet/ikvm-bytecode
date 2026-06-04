using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>same_locals_1_stack_item_frame_extended</c> stack map frame indicating one stack item and unchanged locals with an explicit offset delta.
    /// </summary>
    /// <param name="FrameType">The frame type byte (always 247).</param>
    /// <param name="OffsetDelta">The offset delta from the previous frame.</param>
    /// <param name="Stack">The single verification type on the operand stack.</param>
    public readonly record struct SameLocalsOneExtendedStackMapFrame(byte FrameType, ushort OffsetDelta, VerificationTypeInfo Stack)
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

            if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out SameLocalsOneExtendedStackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU2(out ushort offsetDelta) == false)
                return false;
            if (VerificationTypeInfo.TryRead(ref reader, out var verificationTypeInfo) == false)
                return false;

            frame = new SameLocalsOneExtendedStackMapFrame(frameType, offsetDelta, verificationTypeInfo);
            return true;
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Gets the frame type byte.
        /// </summary>
        public readonly byte FrameType = FrameType;

        /// <summary>
        /// Gets the offset delta from the previous stack map frame.
        /// </summary>
        public readonly ushort OffsetDelta = OffsetDelta;

        /// <summary>
        /// Gets the single stack verification type.
        /// </summary>
        public readonly VerificationTypeInfo Stack = Stack;

        /// <summary>
        /// Copies this frame to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref StackMapTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.SameLocalsOneStackItemExtended(OffsetDelta, e => self.Stack.CopyTo(constantView, constantPool, ref e));
        }

    }

}
