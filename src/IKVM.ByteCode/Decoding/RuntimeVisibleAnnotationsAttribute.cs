using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>RuntimeVisibleAnnotations</c> attribute containing annotations retained at run time.
    /// </summary>
    /// <param name="Annotations">Table of decoded annotations.</param>
    public readonly record struct RuntimeVisibleAnnotationsAttribute(AnnotationTable Annotations)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static RuntimeVisibleAnnotationsAttribute Nil => default;

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            if (AnnotationTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeVisibleAnnotationsAttribute attribute)
        {
            attribute = default;

            if (AnnotationTable.TryRead(ref reader, out var annotations) == false)
                return false;

            attribute = new RuntimeVisibleAnnotationsAttribute(annotations);
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
        /// Gets the table of annotations.
        /// </summary>
        public readonly AnnotationTable Annotations = Annotations;

        /// <summary>
        /// Copies this attribute to the encoder.
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
            var self = this;
            encoder.RuntimeVisibleAnnotations(constantPool.Get(AttributeName.RuntimeVisibleAnnotations), e => self.Annotations.CopyTo(constantView, constantPool, ref e));
        }

    }

}
