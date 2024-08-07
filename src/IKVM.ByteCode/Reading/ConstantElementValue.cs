using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ConstantElementValue(ElementValueKind Kind, ConstantHandle Handle)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
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

        /// <summary>
        /// Attempts to read the data of this element value.
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

        /// <summary>
        /// Attempts to read this element value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, ElementValueKind kind, out ConstantElementValue value)
        {
            value = default;

            if (reader.TryReadU2(out ushort valueIndex) == false)
                return false;

            var constantKind = kind switch
            {
                ElementValueKind.Byte => ConstantKind.Integer,
                ElementValueKind.Char => ConstantKind.Integer,
                ElementValueKind.Double => ConstantKind.Double,
                ElementValueKind.Float => ConstantKind.Float,
                ElementValueKind.Integer => ConstantKind.Integer,
                ElementValueKind.Long => ConstantKind.Long,
                ElementValueKind.Short => ConstantKind.Integer,
                ElementValueKind.Boolean => ConstantKind.Integer,
                ElementValueKind.String => ConstantKind.Utf8,
                _ => throw new ByteCodeException("Invalid attempt to read non-constant element value kind as constant."),
            };

            value = new ConstantElementValue(kind, new ConstantHandle(constantKind, valueIndex));
            return true;
        }

    }

}
