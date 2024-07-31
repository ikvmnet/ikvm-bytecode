namespace IKVM.ByteCode.Parsing
{

    public sealed record PackageConstantRecord(Utf8ConstantHandle Name) : ConstantRecord
    {

        /// <summary>
        /// Parses a Package constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        /// <param name="skip"></param>
        public static bool TryReadPackageConstant(ref ClassFormatReader reader, out ConstantRecord constant, out int skip)
        {
            constant = null;
            skip = 0;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;

            constant = new PackageConstantRecord(new Utf8ConstantHandle(nameIndex));
            return true;
        }

    }

}
