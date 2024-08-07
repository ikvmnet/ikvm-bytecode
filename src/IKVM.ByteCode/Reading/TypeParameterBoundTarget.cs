using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct TypeParameterBoundTarget(byte ParameterIndex, byte BoundIndex)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U1 + ClassFormatReader.U1;
            if (reader.TryAdvance(ClassFormatReader.U1 + ClassFormatReader.U1) == false)
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
            if (reader.TryReadMany(ClassFormatReader.U1+ ClassFormatReader.U1, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out TypeParameterBoundTarget target)
        {
            target = default;

            if (reader.TryReadU1(out byte parameterIndex) == false)
                return false;
            if (reader.TryReadU1(out byte boundIndex) == false)
                return false;

            target = new TypeParameterBoundTarget(parameterIndex, boundIndex);
            return true;
        }

    }

}
