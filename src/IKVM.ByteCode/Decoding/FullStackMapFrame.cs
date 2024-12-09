using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct FullStackMapFrame(byte FrameType, ushort OffsetDelta, VerificationTypeInfoTable Locals, VerificationTypeInfoTable Stack)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
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

        public readonly byte FrameType = FrameType;
        public readonly ushort OffsetDelta = OffsetDelta;
        public readonly VerificationTypeInfoTable Locals = Locals;
        public readonly VerificationTypeInfoTable Stack = Stack;
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
            encoder.Full(OffsetDelta, e => self.Locals.CopyTo(constantView, constantPool, ref e), e => self.Stack.CopyTo(constantView, constantPool, ref e));
        }

    }

}
