using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>same_frame</c> stack map frame indicating no local variable or stack changes.
    /// </summary>
    /// <param name="FrameType">The frame type byte (0–63), which also encodes the offset delta.</param>
    public readonly record struct SameStackMapFrame(byte FrameType)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out SameStackMapFrame frame)
        {
            frame = new SameStackMapFrame(frameType);
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
        /// Gets the frame type byte, which encodes the implicit offset delta.
        /// </summary>
        public readonly byte FrameType = FrameType;

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
            encoder.Same(FrameType);
        }

    }

}
