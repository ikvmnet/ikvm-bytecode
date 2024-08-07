using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct PackageConstant(Utf8ConstantHandle Name)
    {

        /// <summary>
        /// Parses a Package constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <param name="skip"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Package constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out PackageConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;

            constant = new PackageConstant(new Utf8ConstantHandle(nameIndex));
            return true;
        }

    }

}
