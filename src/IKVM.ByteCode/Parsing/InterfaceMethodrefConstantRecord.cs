namespace IKVM.ByteCode.Parsing
{

    public sealed record InterfaceMethodrefConstantRecord(ClassConstantHandle Class, NameAndTypeConstantHandle NameAndType) : RefConstantRecord(Class, NameAndType)
    {

        /// <summary>
        /// Parses a InterfaceMethodref constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryReadInterfaceMethodrefConstant(ref ClassFormatReader reader, out ConstantRecord constant, out int skip)
        {
            constant = null;
            skip = 0;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new InterfaceMethodrefConstantRecord(new(classIndex), new(nameAndTypeIndex));
            return true;
        }

    }

}