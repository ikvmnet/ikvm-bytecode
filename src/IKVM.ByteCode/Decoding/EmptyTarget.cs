using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded empty type annotation target for targets that carry no additional data.
    /// </summary>
    public readonly record struct EmptyTarget()
    {

        /// <summary>
        /// Measures the size of the target structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            return true;
        }

        /// <summary>
        /// Attempts to read the data of this target.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="data">The raw data buffer.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            data = default;
            return true;
        }

        /// <summary>
        /// Attempts to read the target structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="targetInfo"></param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out EmptyTarget targetInfo)
        {
            targetInfo = new EmptyTarget();
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

    }

}