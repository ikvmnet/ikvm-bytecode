using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct DynamicConstant(ushort BootstrapMethodAttributeIndex, NameAndTypeConstantHandle NameAndType)
    {

        /// <summary>
        /// Parses a Dynamic constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <param name="skip"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2 + ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Dynamic constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out DynamicConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort bootstrapMethodAttrIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new DynamicConstant(bootstrapMethodAttrIndex, new(nameAndTypeIndex));
            return true;
        }

    }

}
