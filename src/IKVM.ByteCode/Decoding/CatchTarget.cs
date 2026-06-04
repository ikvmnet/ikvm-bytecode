using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a <c>catch_target</c> type annotation target decoded from a class file.
    /// </summary>
    /// <param name="ExceptionTableIndex">The index into the exception table of the exception catch clause that corresponds to this annotation.</param>
    public readonly record struct CatchTarget(ushort ExceptionTableIndex)
    {

        /// <summary>
        /// Attempts to measure the size of the structure.
        /// </summary>
        /// <param name="reader">The class format reader to advance.</param>
        /// <param name="size">The measured size in bytes, updated on success.</param>
        /// <returns><see langword="true"/> if the size was measured successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the data of this target.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the target from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="target">The decoded target on success.</param>
        /// <returns><see langword="true"/> if the target was read successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out CatchTarget target)
        {
            target = default;

            if (reader.TryReadU2(out ushort exceptionTableIndex) == false)
                return false;

            target = new CatchTarget(exceptionTableIndex);
            return true;
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets the index into the exception table of the exception catch clause.
        /// </summary>
        public readonly ushort ExceptionTableIndex = ExceptionTableIndex;

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