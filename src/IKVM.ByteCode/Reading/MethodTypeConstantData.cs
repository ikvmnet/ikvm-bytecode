using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct MethodTypeConstantData(Utf8ConstantHandle Descriptor)
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
        public static bool TryRead(ref ClassFormatReader reader, out MethodTypeConstantData constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort descriptorIndex) == false)
                return false;

            constant = new MethodTypeConstantData(new Utf8ConstantHandle(descriptorIndex));
            return true;
        }

        public readonly Utf8ConstantHandle Descriptor = Descriptor;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
