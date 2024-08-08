using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct NameAndTypeConstant(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, bool IsNotNil = true)
    {

        /// <summary>
        /// Parses a NameAndType constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <param name="skip"></param>
        public static bool TryReadNameAndTypeConstantData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2+ ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a NameAndType constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryReadNameAndTypeConstant(ref ClassFormatReader reader, out NameAndTypeConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort descriptorIndex) == false)
                return false;

            constant = new NameAndTypeConstant(new(nameIndex), new(descriptorIndex));
            return true;
        }

        public readonly bool IsNil => !IsNotNil;

    }

}
