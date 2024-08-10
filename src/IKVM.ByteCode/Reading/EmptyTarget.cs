using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct EmptyTarget()
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
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
            data = default;
            return true;
        }

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