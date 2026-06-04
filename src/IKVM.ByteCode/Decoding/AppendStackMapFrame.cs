using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents an <c>append_frame</c> stack map frame decoded from a class file.
    /// </summary>
    /// <param name="FrameType">The frame type byte (252–254).</param>
    /// <param name="OffsetDelta">The offset delta to apply to the current bytecode offset.</param>
    /// <param name="Locals">The additional local variable verification types appended by this frame.</param>
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

        /// <summary>
        /// Attempts to read the frame from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="frameType">The frame type byte that was already read.</param>
        /// <param name="frame">The decoded frame on success.</param>
        /// <returns><see langword="true"/> if the frame was read successfully; otherwise <see langword="false"/>.</returns>
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

        /// <summary>
        /// Gets the frame type byte.
        /// </summary>
        public readonly byte FrameType = FrameType;

        /// <summary>
        /// Gets the offset delta to apply to the current bytecode offset.
        /// </summary>
        public readonly ushort OffsetDelta = OffsetDelta;

        /// <summary>
        /// Gets the additional local variable verification types appended by this frame.
        /// </summary>
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
