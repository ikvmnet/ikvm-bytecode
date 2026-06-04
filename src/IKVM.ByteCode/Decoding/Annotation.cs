using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a Java annotation decoded from a class file.
    /// </summary>
    /// <param name="Type">The constant pool handle to the annotation type descriptor.</param>
    /// <param name="Elements">The element value pairs of the annotation.</param>
    public readonly record struct Annotation(Utf8ConstantHandle Type, ElementValuePairTable Elements)
    {

        /// <summary>
        /// Attempts to measure the structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            if (ElementValuePairTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="annotation"></param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out Annotation annotation)
        {
            annotation = default;

            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (ElementValuePairTable.TryRead(ref reader, out var elements) == false)
                return false;

            annotation = new Annotation(new(typeIndex), elements);
            return true;
        }

        /// <summary>
        /// Copies this annotation to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AnnotationEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Annotation(constantPool.Get(constantView.Get(Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void WriteTo(ref AnnotationEncoder encoder)
        {
            var self = this;
            encoder.Annotation(Type, e => self.Elements.WriteTo(ref e));
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
        /// Gets the constant pool handle to the annotation type descriptor.
        /// </summary>
        public readonly Utf8ConstantHandle Type = Type;

        /// <summary>
        /// Gets the element value pairs of this annotation.
        /// </summary>
        public readonly ElementValuePairTable Elements = Elements;

    }

}
