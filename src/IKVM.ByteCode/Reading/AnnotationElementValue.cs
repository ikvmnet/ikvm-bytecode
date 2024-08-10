using System;
using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct AnnotationElementValue(Annotation Annotation)
    {

        /// <summary>
        /// Measures the size of the current element value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            if (Annotation.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            data = default;

            int size = 0;
            if (TryMeasure(ref reader, ref size) == false)
                return false;

            // rewind after measure to read data
            reader.Rewind(size);
            if (reader.TryReadMany(size, out data) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out AnnotationElementValue value)
        {
            value = default;

            if (Annotation.TryRead(ref reader, out var annotation) == false)
                return false;

            value = new AnnotationElementValue(annotation);
            return true;
        }

        public readonly Annotation Annotation = Annotation;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
