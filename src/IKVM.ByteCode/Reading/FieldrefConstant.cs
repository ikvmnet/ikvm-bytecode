using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct FieldrefConstant(ClassConstantHandle Class, NameAndTypeConstantHandle NameAndType, bool IsNotNil = true)
    {

        public static FieldrefConstant Nil => default;

        /// <summary>
        /// Parses a Fieldref constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2 + ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Fieldref constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out FieldrefConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new FieldrefConstant(new(classIndex), new(nameAndTypeIndex));
            return true;
        }

        public readonly bool IsNil => !IsNotNil;

    }

}
