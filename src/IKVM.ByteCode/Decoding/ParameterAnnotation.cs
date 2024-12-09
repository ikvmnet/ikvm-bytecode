using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ParameterAnnotation(AnnotationTable Annotations)
    {

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="parameterAnnotation"></param>
        /// <returns></returns>
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
        /// <param name="reader"></param>
        /// <param name="parameterAnnotation"></param>
        /// <returns></returns>
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
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
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
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AnnotationTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            Annotations.CopyTo(constantView, constantPool, ref encoder);
        }

    }

}
