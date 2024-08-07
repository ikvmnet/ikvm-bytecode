namespace IKVM.ByteCode.Reading
{

    public readonly record struct ParameterAnnotation(AnnotationTable Annotations)
    {

        public static bool TryRead(ref ClassFormatReader reader, out ParameterAnnotation record)
        {
            record = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var annotations = count == 0 ? [] : new Annotation[count];
            for (int i = 0; i < count; i++)
            {
                if (Annotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                annotations[i] = annotation;
            }

            record = new ParameterAnnotation(new(annotations));
            return true;
        }

    }

}
