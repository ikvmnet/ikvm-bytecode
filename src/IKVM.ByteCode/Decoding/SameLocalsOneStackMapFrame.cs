using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct SameLocalsOneStackMapFrame(byte FrameType, VerificationTypeInfo Stack)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
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

        public readonly byte FrameType = FrameType;
        public readonly VerificationTypeInfo Stack = Stack;
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
            encoder.SameLocalsOneStackItem(FrameType, e => self.Stack.CopyTo(constantView, constantPool, ref e));
        }

    }

}
