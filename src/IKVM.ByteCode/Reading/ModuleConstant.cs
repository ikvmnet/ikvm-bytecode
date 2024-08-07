using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleConstant(Utf8ConstantHandle Name)
    {

        /// <summary>
        /// Parses a Module constant in the constant pool.
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
        /// Parses a Module constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out ModuleConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;

            constant = new ModuleConstant(new Utf8ConstantHandle(nameIndex));
            return true;
        }

    }

}
