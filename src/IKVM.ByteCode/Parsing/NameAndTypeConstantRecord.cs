namespace IKVM.ByteCode.Parsing
{

    internal sealed record NameAndTypeConstantRecord(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor) : ConstantRecord
    {

        /// <summary>
        /// Parses a NameAndType constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        /// <param name="skip"></param>
        public static bool TryReadNameAndTypeConstant(ref ClassFormatReader reader, out ConstantRecord constant, out int skip)
        {
            constant = null;
            skip = 0;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort descriptorIndex) == false)
                return false;

            constant = new NameAndTypeConstantRecord(new(nameIndex), new(descriptorIndex));
            return true;
        }

    }

}
