using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Encapsulates an attribute before the contents have been decoded.
    /// </summary>
    /// <param name="Name">The attribute name constant handle.</param>
    /// <param name="Data">The raw attribute data buffer.</param>
    public readonly partial struct Attribute(Utf8ConstantHandle Name, ReadOnlySequence<byte> Data)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static Attribute Nil => default;

        /// <summary>
        /// Parses an attribute.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            size += ClassFormatReader.U4;
            if (reader.TryReadU4(out uint length) == false)
                return false;

            size += checked((int)length);
            if (reader.TryAdvance(length) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses an attribute.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="attribute">The decoded attribute.</param>
        public static bool TryRead(ref ClassFormatReader reader, out Attribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (reader.TryReadU4(out uint length) == false)
                return false;
            if (reader.TryReadMany(length, out var data) == false)
                return false;

            attribute = new Attribute(new(nameIndex), data);
            return true;
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets the name of the attribute.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

        /// <summary>
        /// Gets the backing data of the attribute.
        /// </summary>
        public readonly ReadOnlySequence<byte> Data = Data;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Copies this attribute to the specified attribute encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            EncodeSelfTo(constantView, constantPool, ref encoder);
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void WriteTo(ref AttributeTableEncoder encoder)
        {
            encoder.Attribute(Name, Data);
        }

    }

}
