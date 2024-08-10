using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct DoubleVariableInfo()
    {

        /// <summary>
        /// Measures the size of the current variable info.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            return true;
        }

        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            data = ReadOnlySequence<byte>.Empty;
            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out DoubleVariableInfo record)
        {
            record = new DoubleVariableInfo();
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
