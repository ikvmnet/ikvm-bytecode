using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LongConstant(long Value)
    {

        /// <summary>
        /// Parses a Long constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <param name="skip"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 1;

            if (reader.TryReadMany(ClassFormatReader.U4 + ClassFormatReader.U4, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Long constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out LongConstant constant)
        {
            constant = default;

            if (reader.TryReadU4(out uint a) == false)
                return false;
            if (reader.TryReadU4(out uint b) == false)
                return false;

            constant = new LongConstant((long)(((ulong)a << 32) | b));
            return true;
        }

    }

}
