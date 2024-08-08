using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct SuperTypeTarget(ushort SuperTypeIndex)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
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
            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out SuperTypeTarget target)
        {
            target = default;

            if (reader.TryReadU2(out ushort superTypeIndex) == false)
                return false;

            target = new SuperTypeTarget(superTypeIndex);
            return true;
        }

    }

}