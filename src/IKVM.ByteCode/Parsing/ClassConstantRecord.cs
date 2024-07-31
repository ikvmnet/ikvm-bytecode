namespace IKVM.ByteCode.Parsing
{

    public sealed record ClassConstantRecord(Utf8ConstantHandle Name) : ConstantRecord
    {

        /// <summary>
        /// Parses a Class constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryReadClassConstant(ref ClassFormatReader reader, out ConstantRecord constant, out int skip)
        {
            constant = null;
            skip = 0;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;

            constant = new ClassConstantRecord(new Utf8ConstantHandle(nameIndex));
            return true;
        }

    }

}
