using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct TypeArgumentTarget(ushort Offset, byte TypeArgumentIndex)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2 + ClassFormatReader.U1;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U1) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the data of this target.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            if (reader.TryReadMany(ClassFormatReader.U2 + ClassFormatReader.U1, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out TypeArgumentTarget targetInfo)
        {
            targetInfo = default;

            if (reader.TryReadU2(out ushort offset) == false)
                return false;
            if (reader.TryReadU1(out byte typeArgumentIndex) == false)
                return false;

            targetInfo = new TypeArgumentTarget(offset, typeArgumentIndex);
            return true;
        }

        public readonly ushort Offset = Offset;
        public readonly byte TypeArgumentIndex = TypeArgumentIndex;
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