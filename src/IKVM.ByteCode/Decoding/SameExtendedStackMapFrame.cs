using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>same_frame_extended</c> stack map frame indicating no local variable or stack changes with an explicit offset delta.
    /// </summary>
    /// <param name="FrameType">The frame type byte (always 251).</param>
    /// <param name="OffsetDelta">The offset delta from the previous frame.</param>
    public readonly record struct SameExtendedStackMapFrame(byte FrameType, ushort OffsetDelta)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="frameType">The stack map frame type tag byte.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out SameExtendedStackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU2(out ushort offsetDelta) == false)
                return false;

            frame = new SameExtendedStackMapFrame(frameType, offsetDelta);
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
            encoder.SameExtended(OffsetDelta);
        }

    }


}
