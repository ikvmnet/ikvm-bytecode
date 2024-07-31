namespace IKVM.ByteCode.Parsing
{

    public sealed record RuntimeVisibleTypeAnnotationsAttributeRecord(TypeAnnotationRecord[] Annotations) : AttributeRecord
    {

        public static bool TryReadRuntimeVisibleTypeAnnotationsAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var annotations = new TypeAnnotationRecord[count];
            for (int i = 0; i < count; i++)
            {
                if (TypeAnnotationRecord.TryReadTypeAnnotation(ref reader, out var annotation) == false)
                    return false;

                annotations[i] = annotation;
            }

            attribute = new RuntimeVisibleTypeAnnotationsAttributeRecord(annotations);
            return true;
        }

    }

}