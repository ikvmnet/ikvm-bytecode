using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct RuntimeVisibleAnnotationsAttribute(AnnotationTable Annotations)
    {

        public static RuntimeVisibleAnnotationsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeVisibleAnnotationsAttribute attribute)
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

            attribute = new RuntimeVisibleAnnotationsAttribute(new(items));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
