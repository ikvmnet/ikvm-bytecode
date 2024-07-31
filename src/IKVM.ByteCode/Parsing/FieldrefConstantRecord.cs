namespace IKVM.ByteCode.Parsing
{

    public sealed record FieldrefConstantRecord(ClassConstantHandle Class, NameAndTypeConstantHandle NameAndType) : RefConstantRecord(Class, NameAndType)
    {

        /// <summary>
        /// Parses a Fieldref constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryReadFieldrefConstant(ref ClassFormatReader reader, out ConstantRecord constant, out int skip)
        {
            constant = null;
            skip = 0;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new FieldrefConstantRecord(new(classIndex), new(nameAndTypeIndex));
            return true;
        }

    }

}
