using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct AppendStackMapFrame(byte FrameType, ushort OffsetDelta, VerificationTypeInfoTable Locals)
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

            for (int i = 0; i < frameType - 251; i++)
                if (VerificationTypeInfo.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out AppendStackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU2(out ushort offsetDelta) == false)
                return false;

            var locals = new VerificationTypeInfo[frameType - 251];
            for (int i = 0; i < frameType - 251; i++)
            {
                if (VerificationTypeInfo.TryRead(ref reader, out var local) == false)
                    return false;

                locals[i] = local;
            }

            frame = new AppendStackMapFrame(frameType, offsetDelta, new(locals));
            return true;
        }

        /// <summary>
        /// Copies this frame to the specified encoder.
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
            encoder.Append(FrameType, OffsetDelta, e => self.Locals.CopyTo(constantView, constantPool, ref e));
        }

        public readonly byte FrameType = FrameType;
        public readonly ushort OffsetDelta = OffsetDelta;
        public readonly VerificationTypeInfoTable Locals = Locals;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
