namespace IKVM.ByteCode.Reading
{

    public readonly record struct RuntimeVisibleTypeAnnotationsAttribute(TypeAnnotationTable Annotations, bool IsNotNil = true)
    {

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

        public bool IsNil => !IsNotNil;

    }

}