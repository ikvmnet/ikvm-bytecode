namespace IKVM.ByteCode.Parsing
{

    public sealed record ElementValueAnnotationValueRecord(AnnotationRecord Annotation) : ElementValueValueRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out ElementValueValueRecord value)
        {
            value = null;

            if (AnnotationRecord.TryReadAnnotation(ref reader, out var annotation) == false)
                return false;

            value = new ElementValueAnnotationValueRecord(annotation);
            return true;
        }

    }

}
