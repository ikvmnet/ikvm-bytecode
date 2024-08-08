using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct MethodTypeConstant(Utf8ConstantHandle Descriptor, bool IsNotNil = true)
    {

        /// <summary>
        /// Parses a MethodType constant in the constant pool.
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
        /// Parses a MethodType constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out MethodTypeConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort descriptorIndex) == false)
                return false;

            constant = new MethodTypeConstant(new Utf8ConstantHandle(descriptorIndex));
            return true;
        }

        public readonly bool IsNil => !IsNotNil;

    }

}
