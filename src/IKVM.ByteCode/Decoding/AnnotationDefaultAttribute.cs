using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the decoded <c>AnnotationDefault</c> attribute of a class file method.
    /// </summary>
    /// <param name="DefaultValue">The default element value of the annotation type element.</param>
    public readonly record struct AnnotationDefaultAttribute(ElementValue DefaultValue)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static AnnotationDefaultAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="attribute">The decoded attribute on success.</param>
        /// <returns><see langword="true"/> if the attribute was read successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out AnnotationDefaultAttribute attribute)
        {
            attribute = default;

            if (ElementValue.TryRead(ref reader, out var defaultValue) == false)
                return false;

            attribute = new AnnotationDefaultAttribute(defaultValue);
            return true;
        }

        /// <summary>
        /// Gets the default element value of the annotation type element.
        /// </summary>
        public readonly ElementValue DefaultValue = DefaultValue;
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
            encoder.AnnotationDefault(constantPool.Get(AttributeName.AnnotationDefault), e => self.DefaultValue.CopyTo(constantView, constantPool, ref e));
        }

    }

}
