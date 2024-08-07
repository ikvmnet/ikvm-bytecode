using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct RuntimeVisibleAnnotationsAttribute(ReadOnlyMemory<Annotation> Annotations, bool IsNotNil = true)
    {

        public static RuntimeVisibleAnnotationsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeVisibleAnnotationsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var items = new Annotation[count];
            for (int i = 0; i < count; i++)
            {
                if (Annotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                items[i] = annotation;
            }

            attribute = new RuntimeVisibleAnnotationsAttribute(items);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
