using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct EnumElementValue(Utf8ConstantHandle TypeName, Utf8ConstantHandle ConstantName)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            if (reader.TryReadMany(ClassFormatReader.U2 + ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out EnumElementValue value)
        {
            value = default;

            if (reader.TryReadU2(out ushort typeNameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort constantNameIndex) == false)
                return false;

            value = new EnumElementValue(new(typeNameIndex), new(constantNameIndex));
            return true;
        }

    }

}
