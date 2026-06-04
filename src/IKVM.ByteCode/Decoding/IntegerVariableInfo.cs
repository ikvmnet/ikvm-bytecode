using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents an <c>Integer_variable_info</c> verification type decoded from a stack map frame.
    /// </summary>
    public readonly record struct IntegerVariableInfo()
    {

        /// <summary>
        /// Measures the size of the current variable info.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            return true;
        }

        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            data = ReadOnlySequence<byte>.Empty;
            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out IntegerVariableInfo record)
        {
            record = new IntegerVariableInfo();
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
