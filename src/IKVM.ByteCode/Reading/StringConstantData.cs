using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct StringConstantData(Utf8ConstantHandle Value)
    {

        /// <summary>
        /// Parses a Class constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <param name="skip"></param>
        public static bool TryReadStringConstantData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Class constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryReadStringConstant(ref ClassFormatReader reader, out StringConstantData constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort valueIndex) == false)
                return false;

            constant = new StringConstantData(new Utf8ConstantHandle(valueIndex));
            return true;
        }

    }

}
