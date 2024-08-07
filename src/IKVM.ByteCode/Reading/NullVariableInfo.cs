using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct NullVariableInfo
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

        public static bool TryRead(ref ClassFormatReader reader, out NullVariableInfo record)
        {
            record = new NullVariableInfo();
            return true;
        }

    }

}
