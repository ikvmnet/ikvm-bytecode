using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct RuntimeInvisibleParameterAnnotationsAttribute(ParameterAnnotationTable Parameters)
    {

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

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
