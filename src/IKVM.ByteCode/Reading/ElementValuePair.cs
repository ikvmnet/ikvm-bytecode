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

    }

}
