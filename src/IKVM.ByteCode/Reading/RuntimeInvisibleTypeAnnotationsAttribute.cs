namespace IKVM.ByteCode.Reading
{

    public readonly record struct RuntimeInvisibleTypeAnnotationsAttribute(TypeAnnotationTable Annotations, bool IsNotNil = true)
    {

        public static RuntimeInvisibleTypeAnnotationsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeInvisibleTypeAnnotationsAttribute attribute)
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

            attribute = new RuntimeInvisibleTypeAnnotationsAttribute(new(annotations));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
