﻿using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ThrowsTarget(ushort ThrowsTypeIndex)
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

        public static bool TryRead(ref ClassFormatReader reader, out ThrowsTarget target)
        {
            target = default;

            if (reader.TryReadU2(out ushort throwsTypeIndex) == false)
                return false;

            target = new ThrowsTarget(throwsTypeIndex);
            return true;
        }

    }

}