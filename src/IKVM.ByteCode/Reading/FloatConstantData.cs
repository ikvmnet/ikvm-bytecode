using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct FloatConstantData(float Value)
    {

        /// <summary>
        /// Parses a Float constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U4, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Float constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead( ref ClassFormatReader reader, out FloatConstantData constant)
        {
            constant = default;

            if (reader.TryReadU4(out uint value) == false)
                return false;

            constant = new FloatConstantData(RawBitConverter.UInt32BitsToSingle(value));
            return true;
        }

    }

}
