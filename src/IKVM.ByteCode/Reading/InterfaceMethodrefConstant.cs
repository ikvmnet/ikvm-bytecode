using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct InterfaceMethodrefConstant(ClassConstantHandle Class, NameAndTypeConstantHandle NameAndType, bool IsNotNil = true)
    {

        /// <summary>
        /// Parses a InterfaceMethodref constant in the constant pool.
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
        /// Parses a InterfaceMethodref constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out InterfaceMethodrefConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new InterfaceMethodrefConstant(new(classIndex), new(nameAndTypeIndex));
            return true;
        }

        public readonly bool IsNil => !IsNotNil;

    }

}