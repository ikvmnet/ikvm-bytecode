using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded annotations for a single method parameter.
    /// </summary>
    /// <param name="Annotations">Table of annotations applied to this parameter.</param>
    public readonly record struct ParameterAnnotation(AnnotationTable Annotations)
    {

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort count) == false)
                return false;

            for (int i = 0; i < count; i++)
                if (Annotation.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="parameterAnnotation">The decoded parameter annotation.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ParameterAnnotation parameterAnnotation)
        {
            parameterAnnotation = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var annotations = count == 0 ? [] : new Annotation[count];
            for (int i = 0; i < count; i++)
            {
                if (Annotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                annotations[i] = annotation;
            }

            parameterAnnotation = new ParameterAnnotation(new(annotations));
            return true;
        }

        /// <summary>
        /// Gets the annotations for this parameter.
        /// </summary>
        public readonly AnnotationTable Annotations = Annotations;
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
        /// Copies this annotation to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ParameterAnnotationTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.ParameterAnnotation(e => self.CopyTo(constantView, constantPool, ref e));
        }

        /// <summary>
        /// Copies this aannotation to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AnnotationTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            Annotations.CopyTo(constantView, constantPool, ref encoder);
        }

    }

}
