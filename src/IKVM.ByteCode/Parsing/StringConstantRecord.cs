namespace IKVM.ByteCode.Parsing
{

    internal sealed record StringConstantRecord(Utf8ConstantHandle Value) : ConstantRecord
    {

        /// <summary>
        /// Parses a Class constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryReadStringConstant(ref ClassFormatReader reader, out ConstantRecord constant, out int skip)
        {
            constant = null;
            skip = 0;

            if (reader.TryReadU2(out ushort valueIndex) == false)
                return false;

            constant = new StringConstantRecord(new Utf8ConstantHandle(valueIndex));
            return true;
        }

    }

}
