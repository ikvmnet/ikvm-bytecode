using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ElementValuePair(Utf8ConstantHandle Name, ElementValue Value)
    {

        /// <summary>
        /// Measures the size of the current element value pair.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;

            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;
            if (ElementValue.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attemps to read an element value pair.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out ElementValuePair pair)
        {
            pair = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (ElementValue.TryRead(ref reader, out var value) == false)
                return false;

            pair = new ElementValuePair(new(nameIndex), value);
            return true;
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref ElementValuePairTableEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var self = this;
            encoder.Element(pool.Import(view, Name), e => self.Value.EncodeTo(view, pool, ref e));
        }

    }

}
