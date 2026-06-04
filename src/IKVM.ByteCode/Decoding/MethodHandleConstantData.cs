using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the data of a <c>CONSTANT_MethodHandle_info</c> entry decoded from the constant pool.
    /// </summary>
    /// <param name="Kind">The reference kind describing how the method handle is used.</param>
    /// <param name="Reference">The constant pool handle to the underlying field or method reference.</param>
    public readonly record struct MethodHandleConstantData(MethodHandleKind Kind, RefConstantHandle Reference)
    {

        /// <summary>
        /// Measures a constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <param name="skip">The number of bytes to skip.</param>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size, out int skip)
        {
            skip = 0;

            size += ClassFormatReader.U1 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U1 + ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a MethodHandle constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="data">The raw data buffer.</param>
        /// <param name="skip">The number of bytes to skip.</param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U1 + ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a MethodHandle constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="constant">The decoded constant.</param>
        public static bool TryRead(ref ClassFormatReader reader, out MethodHandleConstantData constant)
        {
            constant = default;

            if (reader.TryReadU1(out byte referenceKind) == false)
                return false;
            if (reader.TryReadU2(out ushort referenceIndex) == false)
                return false;

            constant = new MethodHandleConstantData((MethodHandleKind)referenceKind, new(ConstantKind.Unknown, referenceIndex));
            return true;
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Gets the reference kind describing how the method handle is used.
        /// </summary>
        public readonly MethodHandleKind Kind = Kind;

        /// <summary>
        /// Gets the constant pool handle to the underlying field or method reference.
        /// </summary>
        public readonly RefConstantHandle Reference = Reference;

    }

}
