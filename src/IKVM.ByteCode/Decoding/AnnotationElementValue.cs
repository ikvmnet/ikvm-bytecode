using System;
using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents an annotation element value decoded from a class file.
    /// </summary>
    /// <param name="Annotation">The annotation value.</param>
    public readonly record struct AnnotationElementValue(Annotation Annotation)
    {

        /// <summary>
        /// Measures the size of the current element value.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            if (Annotation.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the raw data bytes of the element value.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="data">The raw bytes of the element value on success.</param>
        /// <returns><see langword="true"/> if the data was read successfully; otherwise <see langword="false"/>.</returns>
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

        /// <summary>
        /// Attempts to read the annotation element value from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="value">The decoded element value on success.</param>
        /// <returns><see langword="true"/> if the value was read successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out AnnotationElementValue value)
        {
            value = default;

            if (Annotation.TryRead(ref reader, out var annotation) == false)
                return false;

            value = new AnnotationElementValue(annotation);
            return true;
        }

        /// <summary>
        /// Gets the annotation value.
        /// </summary>
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
