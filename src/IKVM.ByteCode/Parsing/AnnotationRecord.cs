namespace IKVM.ByteCode.Parsing
{

    public readonly record struct AnnotationRecord(Utf8ConstantHandle Type, ElementValuePairRecord[] Elements)
    {

        public static bool TryReadAnnotation(ref ClassFormatReader reader, out AnnotationRecord annotation)
        {
            annotation = default;

            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort pairCount) == false)
                return false;

            var elements = new ElementValuePairRecord[pairCount];
            for (int i = 0; i < pairCount; i++)
            {
                if (ElementValuePairRecord.TryRead(ref reader, out var element) == false)
                    return false;

                elements[i] = element;
            }

            annotation = new AnnotationRecord(new (typeIndex), elements);
            return true;
        }

    }

}
