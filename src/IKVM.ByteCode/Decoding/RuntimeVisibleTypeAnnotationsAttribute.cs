using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>RuntimeVisibleTypeAnnotations</c> attribute containing type annotations retained at run time.
    /// </summary>
    /// <param name="TypeAnnotations">Table of decoded type annotations.</param>
    public readonly record struct RuntimeVisibleTypeAnnotationsAttribute(TypeAnnotationTable TypeAnnotations)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static RuntimeVisibleTypeAnnotationsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeVisibleTypeAnnotationsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var annotations = count == 0 ? [] : new TypeAnnotation[count];
            for (int i = 0; i < count; i++)
            {
                if (TypeAnnotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                annotations[i] = annotation;
            }

            attribute = new RuntimeVisibleTypeAnnotationsAttribute(new(annotations));
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
        /// Gets the table of type annotations.
        /// </summary>
        public readonly TypeAnnotationTable TypeAnnotations = TypeAnnotations;

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
            encoder.RuntimeVisibleTypeAnnotations(constantPool.Get(AttributeName.RuntimeVisibleTypeAnnotations), e => self.TypeAnnotations.CopyTo(constantView, constantPool, ref e));
        }

    }

}