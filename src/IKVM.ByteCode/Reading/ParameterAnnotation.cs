using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ParameterAnnotation(ReadOnlyMemory<Annotation> Annotations)
    {

        public static bool TryRead(ref ClassFormatReader reader, out ParameterAnnotation record)
        {
            record = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var annotations = new Annotation[count];
            for (int i = 0; i < count; i++)
            {
                if (Annotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                annotations[i] = annotation;
            }

            record = new ParameterAnnotation(annotations);
            return true;
        }

    }

}
