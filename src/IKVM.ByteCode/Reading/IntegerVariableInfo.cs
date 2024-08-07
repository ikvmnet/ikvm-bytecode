﻿using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct IntegerVariableInfo
    {

        /// <summary>
        /// Measures the size of the current variable info.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            return true;
        }

        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            data = ReadOnlySequence<byte>.Empty;
            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out IntegerVariableInfo record)
        {
            record = new IntegerVariableInfo();
            return true;
        }

    }

}