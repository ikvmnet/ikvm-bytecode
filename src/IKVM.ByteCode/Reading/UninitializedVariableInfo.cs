﻿using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct UninitializedVariableInfo(ushort Offset)
    {

        /// <summary>
        /// Measures the size of the current variable info.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out UninitializedVariableInfo record)
        {
            record = default;

            if (reader.TryReadU2(out ushort offset) == false)
                return false;

            record = new UninitializedVariableInfo(offset);
            return true;
        }

    }

}
