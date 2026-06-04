using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a <c>full_frame</c> stack map frame decoded from a class file.
    /// </summary>
    /// <param name="FrameType">The frame type byte (255).</param>
    /// <param name="OffsetDelta">The offset delta to apply to the current bytecode offset.</param>
    /// <param name="Locals">The complete set of local variable verification types.</param>
    /// <param name="Stack">The complete set of operand stack verification types.</param>
    public readonly record struct FullStackMapFrame(byte FrameType, ushort OffsetDelta, VerificationTypeInfoTable Locals, VerificationTypeInfoTable Stack)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out var localsCount) == false)
                return false;

            for (var i = 0; i < localsCount; i++)
                if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                    return false;

            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out var stackCount) == false)
                return false;

            for (var i = 0; i < stackCount; i++)
                if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte tag, out FullStackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU2(out ushort offsetDelta) == false)
                return false;
            if (reader.TryReadU2(out ushort localsCount) == false)
                return false;

            var locals = localsCount == 0 ? [] : new VerificationTypeInfo[localsCount];
            for (int i = 0; i < localsCount; i++)
                if (VerificationTypeInfo.TryRead(ref reader, out locals[i]) == false)
                    return false;

            if (reader.TryReadU2(out ushort stackCount) == false)
                return false;

            var stack = stackCount == 0 ? [] : new VerificationTypeInfo[stackCount];
            for (int i = 0; i < stackCount; i++)
                if (VerificationTypeInfo.TryRead(ref reader, out stack[i]) == false)
                    return false;

            frame = new FullStackMapFrame(tag, offsetDelta, new(locals), new(stack));
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
        /// Gets the offset delta to apply to the current bytecode offset.
        /// </summary>
        public readonly ushort OffsetDelta = OffsetDelta;

        /// <summary>
        /// Gets the complete set of local variable verification types.
        /// </summary>
        public readonly VerificationTypeInfoTable Locals = Locals;

        /// <summary>
        /// Gets the complete set of operand stack verification types.
        /// </summary>
        public readonly VerificationTypeInfoTable Stack = Stack;

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
            encoder.Full(OffsetDelta, e => self.Locals.CopyTo(constantView, constantPool, ref e), e => self.Stack.CopyTo(constantView, constantPool, ref e));
        }

    }

}
