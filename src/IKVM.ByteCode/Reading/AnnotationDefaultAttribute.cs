namespace IKVM.ByteCode.Reading
{

    public readonly record struct AnnotationDefaultAttribute(ElementValue DefaultValue)
    {

        public static AnnotationDefaultAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out AnnotationDefaultAttribute attribute)
        {
            attribute = default;

            if (ElementValue.TryRead(ref reader, out var defaultValue) == false)
                return false;

            attribute = new AnnotationDefaultAttribute(defaultValue);
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
