using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct SameStackMapFrame(byte FrameType)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out SameStackMapFrame frame)
        {
            frame = new SameStackMapFrame(frameType);
            return true;
        }

        public readonly byte FrameType = FrameType;
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
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantMap>(TConstantMap map, ref StackMapTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            encoder.Same(FrameType);
        }

    }

}
