using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a class element value decoded from a class file annotation.
    /// </summary>
    /// <param name="Class">The constant pool handle to the UTF-8 class info descriptor.</param>
    public readonly record struct ClassElementValue(Utf8ConstantHandle Class)
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

        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            if (reader.TryReadMany(ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out ClassElementValue value)
        {
            value = default;

            if (reader.TryReadU2(out ushort classInfoIndex) == false)
                return false;

            value = new ClassElementValue(new Utf8ConstantHandle(classInfoIndex));
            return true;
        }

        /// <summary>
        /// Gets the constant pool handle to the UTF-8 class info descriptor.
        /// </summary>
        public readonly Utf8ConstantHandle Class = Class;
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