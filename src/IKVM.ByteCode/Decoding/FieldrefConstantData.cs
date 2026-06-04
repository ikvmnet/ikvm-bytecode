using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the data of a <c>CONSTANT_Fieldref_info</c> entry decoded from the constant pool.
    /// </summary>
    /// <param name="Class">The constant pool handle to the class that contains the field.</param>
    /// <param name="NameAndType">The constant pool handle to the name and type descriptor of the field.</param>
    public readonly record struct FieldrefConstantData(ClassConstantHandle Class, NameAndTypeConstantHandle NameAndType)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static FieldrefConstantData Nil => default;

        /// <summary>
        /// Measures a constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <param name="skip"></param>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size, out int skip)
        {
            skip = 0;

            size += ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Fieldref constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2 + ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a Fieldref constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out FieldrefConstantData constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new FieldrefConstantData(new(classIndex), new(nameAndTypeIndex));
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
        /// Gets the constant pool handle to the class that contains the field.
        /// </summary>
        public readonly ClassConstantHandle Class = Class;

        /// <summary>
        /// Gets the constant pool handle to the name and type descriptor of the field.
        /// </summary>
        public readonly NameAndTypeConstantHandle NameAndType = NameAndType;

    }

}
