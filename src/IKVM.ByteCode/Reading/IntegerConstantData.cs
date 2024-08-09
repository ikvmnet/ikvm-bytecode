using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct IntegerConstantData(int Value)
    {

        /// <summary>
        /// Parses a Integer constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <param name="skip"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U4, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Integer constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead( ref ClassFormatReader reader, out IntegerConstantData constant)
        {
            constant = default;

            if (reader.TryReadU4(out uint value) == false)
                return false;

            constant = new IntegerConstantData(unchecked((int)value));
            return true;
        }

    }

}
