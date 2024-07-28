namespace IKVM.ByteCode.Parsing
{

    internal sealed record ElementValueClassValueRecord(Utf8ConstantHandle Class) : ElementValueValueRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out ElementValueValueRecord value)
        {
            value = null;

            if (reader.TryReadU2(out ushort classInfoIndex) == false)
                return false;

            value = new ElementValueClassValueRecord(new Utf8ConstantHandle(classInfoIndex));
            return true;
        }

        public override int GetSize()
        {
            var size = 0;
            size += sizeof(ushort);
            return size;
        }

        /// <summary>
        /// Attempts to write the record to the given <see cref="ClassFormatWriter"/>.
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public override bool TryWrite(ref ClassFormatWriter writer)
        {
            if (writer.TryWriteU2(Class.Value) == false)
                return false;

            return true;
        }

    }

}