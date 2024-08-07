using System;
using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVarTarget(ReadOnlyMemory<LocalVarTargetItem> Items)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort length) == false)
                return false;

            for (int i = 0; i < length; i++)
                if (LocalVarTargetItem.TryMeasure(ref reader, ref size) == false)
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
            data = default;

            int size = 0;
            if (TryMeasure(ref reader, ref size) == false)
                return false;

            // rewind after measure to read data
            reader.Rewind(size);
            if (reader.TryReadMany(size, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out LocalVarTarget target)
        {
            target = default;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var items = new LocalVarTargetItem[length];
            for (int i = 0; i < length; i++)
                if (LocalVarTargetItem.TryRead(ref reader, out items[i]) == false)
                    return false;

            target = new LocalVarTarget(items);
            return true;
        }

    }

}