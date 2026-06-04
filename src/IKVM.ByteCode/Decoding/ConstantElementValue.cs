using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a constant element value decoded from a class file annotation.
    /// </summary>
    /// <param name="Kind">The kind of the element value.</param>
    /// <param name="Handle">The constant pool handle to the constant value.</param>
    public readonly record struct ConstantElementValue(ElementValueKind Kind, ConstantHandle Handle)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
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
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="data">The raw data buffer.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read this element value.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="value">The decoded value.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
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

        /// <summary>
        /// Gets the kind of the element value.
        /// </summary>
        public readonly ElementValueKind Kind = Kind;

        /// <summary>
        /// Gets the constant pool handle to the constant value.
        /// </summary>
        public readonly ConstantHandle Handle = Handle;
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
