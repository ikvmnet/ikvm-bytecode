namespace IKVM.ByteCode.Reading
{

    public readonly record struct RuntimeInvisibleAnnotationsAttribute(AnnotationTable Annotations)
    {

        public static RuntimeInvisibleAnnotationsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeInvisibleAnnotationsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var items = count == 0 ? [] : new Annotation[count];
            for (int i = 0; i < count; i++)
            {
                if (Annotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                items[i] = annotation;
            }

            attribute = new RuntimeInvisibleAnnotationsAttribute(new(items));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}