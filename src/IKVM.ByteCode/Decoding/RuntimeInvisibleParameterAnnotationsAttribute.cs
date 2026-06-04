using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>RuntimeInvisibleParameterAnnotations</c> attribute containing per-parameter annotations not retained at run time.
    /// </summary>
    /// <param name="ParameterAnnotations">Table of parameter annotation entries.</param>
    public readonly record struct RuntimeInvisibleParameterAnnotationsAttribute(ParameterAnnotationTable ParameterAnnotations)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static RuntimeInvisibleParameterAnnotationsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeInvisibleParameterAnnotationsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU1(out byte count) == false)
                return false;

            var parameters = count == 0 ? [] : new ParameterAnnotation[count];
            for (int i = 0; i < count; i++)
            {
                if (ParameterAnnotation.TryRead(ref reader, out var parameter) == false)
                    return false;

                parameters[i] = parameter;
            }

            attribute = new RuntimeInvisibleParameterAnnotationsAttribute(new(parameters));
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
        /// Gets the per-parameter annotation entries.
        /// </summary>
        public readonly ParameterAnnotationTable ParameterAnnotations = ParameterAnnotations;

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
            encoder.RuntimeInvisibleParameterAnnotations(constantPool.Get(AttributeName.RuntimeInvisibleParameterAnnotations), e => self.ParameterAnnotations.CopyTo(constantView, constantPool, ref e));
        }

    }

}
