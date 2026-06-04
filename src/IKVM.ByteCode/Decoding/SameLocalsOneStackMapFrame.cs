using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>same_locals_1_stack_item_frame</c> stack map frame indicating one stack item and unchanged locals.
    /// </summary>
    /// <param name="FrameType">The frame type byte (64–127).</param>
    /// <param name="Stack">The single verification type on the operand stack.</param>
    public readonly record struct SameLocalsOneStackMapFrame(byte FrameType, VerificationTypeInfo Stack)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out SameLocalsOneStackMapFrame frame)
        {
            frame = default;

            if (VerificationTypeInfo.TryRead(ref reader, out var stack) == false)
                return false;

            frame = new SameLocalsOneStackMapFrame(frameType, stack);
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
        /// Gets the single stack verification type.
        /// </summary>
        public readonly VerificationTypeInfo Stack = Stack;

        /// <summary>
        /// Copies this frame to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref StackMapTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.SameLocalsOneStackItem(FrameType, e => self.Stack.CopyTo(constantView, constantPool, ref e));
        }

    }

}
