using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a <c>chop_frame</c> stack map frame decoded from a class file.
    /// </summary>
    /// <param name="FrameType">The frame type byte (248–250).</param>
    /// <param name="OffsetDelta">The offset delta to apply to the current bytecode offset.</param>
    public readonly record struct ChopStackMapFrame(byte FrameType, ushort OffsetDelta)
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

            return true;
        }

        /// <summary>
        /// Attempts to read the frame from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="frameType">The frame type byte that was already read.</param>
        /// <param name="frame">The decoded frame on success.</param>
        /// <returns><see langword="true"/> if the frame was read successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out ChopStackMapFrame frame)
        {
            frame = default;

            if (reader.TryReadU2(out ushort offsetDelta) == false)
                return false;

            frame = new ChopStackMapFrame(frameType, offsetDelta);
            return true;
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map">The stack map frame encoder.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool,ref StackMapTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.Chop(FrameType, OffsetDelta);
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets the frame type byte.
        /// </summary>
        public readonly byte FrameType = FrameType;

        /// <summary>
        /// Gets the offset delta to apply to the current bytecode offset.
        /// </summary>
        public readonly ushort OffsetDelta = OffsetDelta;

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
