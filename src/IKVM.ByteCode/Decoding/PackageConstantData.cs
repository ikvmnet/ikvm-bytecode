using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>CONSTANT_Package_info</c> constant pool entry.
    /// </summary>
    /// <param name="Name">Handle to the package name constant.</param>
    public readonly record struct PackageConstantData(Utf8ConstantHandle Name)
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

            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Package constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="data">The raw data buffer.</param>
        /// <param name="skip">The number of bytes to skip.</param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Package constant in the constant pool.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="constant">The decoded constant.</param>
        public static bool TryRead(ref ClassFormatReader reader, out PackageConstantData constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;

            constant = new PackageConstantData(new Utf8ConstantHandle(nameIndex));
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
        /// Gets the package name.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

    }

}
