using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct Annotation(Utf8ConstantHandle Type, ElementValuePairTable Elements)
    {

        /// <summary>
        /// Measures the size of the current annotation.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;

            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;
            if (ElementValuePairTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read an annotation.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="annotation"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out Annotation annotation)
        {
            annotation = default;

            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (ElementValuePairTable.TryRead(ref reader, out var elements) == false)
                return false;

            annotation = new Annotation(new(typeIndex), elements);
            return true;
        }

        /// <summary>
        /// Imports a <see cref="Annotation"/>.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref AnnotationEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var self = this;
            encoder.Annotation(pool.Import(view, Type), e => self.Elements.EncodeTo(view, pool, ref e));
        }

    }

}
