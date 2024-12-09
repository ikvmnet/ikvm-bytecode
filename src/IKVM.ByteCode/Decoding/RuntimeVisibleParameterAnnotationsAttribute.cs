using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct RuntimeVisibleParameterAnnotationsAttribute(ParameterAnnotationTable ParameterAnnotations)
    {

        public static RuntimeVisibleParameterAnnotationsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeVisibleParameterAnnotationsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU1(out byte count) == false)
                return false;

            var items = count == 0 ? [] : new ParameterAnnotation[count];
            for (int i = 0; i < count; i++)
            {
                if (ParameterAnnotation.TryRead(ref reader, out var parameter) == false)
                    return false;

                items[i] = parameter;
            }

            attribute = new RuntimeVisibleParameterAnnotationsAttribute(new(items));
            return true;
        }

        public readonly ParameterAnnotationTable ParameterAnnotations = ParameterAnnotations;
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
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.RuntimeVisibleParameterAnnotations(constantPool.Get(AttributeName.RuntimeVisibleParameterAnnotations), e => self.ParameterAnnotations.CopyTo(constantView, constantPool, ref e));
        }

    }

}
