using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a name-value pair in an annotation decoded from a class file.
    /// </summary>
    /// <param name="Name">The constant pool handle to the UTF-8 element name.</param>
    /// <param name="Value">The element value.</param>
    public readonly record struct ElementValuePair(Utf8ConstantHandle Name, ElementValue Value)
    {

        /// <summary>
        /// Measures the size of the current element value pair.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            if (ElementValue.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attemps to read an element value pair.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="pair">The decoded element-value pair.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ElementValuePair pair)
        {
            pair = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (ElementValue.TryRead(ref reader, out var value) == false)
                return false;

            pair = new ElementValuePair(new(nameIndex), value);
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
        /// Gets the constant pool handle to the UTF-8 element name.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

        /// <summary>
        /// Gets the element value.
        /// </summary>
        public readonly ElementValue Value = Value;

        /// <summary>
        /// Copies this pair to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ElementValuePairTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Element(constantPool.Get(constantView.Get(Name)), e => self.Value.CopyTo(constantView, constantPool, ref e));
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void WriteTo(ref ElementValuePairTableEncoder encoder)
        {
            var self = this;
            encoder.Element(Name, e => self.Value.WriteTo(ref e));
        }

    }

}
