namespace IKVM.ByteCode.Reading
{

    public readonly record struct RuntimeVisibleParameterAnnotationsAttribute(ParameterAnnotationTable Parameters, bool IsNotNil = true)
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

        public bool IsNil => !IsNotNil;

    }

}
