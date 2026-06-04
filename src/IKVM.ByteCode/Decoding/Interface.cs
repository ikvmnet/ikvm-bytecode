namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents an interface entry in the interfaces table of a decoded class file.
    /// </summary>
    /// <param name="Class">The constant pool handle to the interface class.</param>
    public readonly record struct Interface(ClassConstantHandle Class)
    {

        /// <summary>
        /// Parses an interface.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses an interface.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="iface">The decoded interface entry.</param>
        public static bool TryRead(ref ClassFormatReader reader, out Interface iface)
        {
            iface = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;

            iface = new Interface(new(classIndex));
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
        /// Gets the constant pool handle to the interface class.
        /// </summary>
        public readonly ClassConstantHandle Class = Class;

    }

}
