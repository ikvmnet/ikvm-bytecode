namespace IKVM.ByteCode.Reading
{

    public readonly record struct Interface(ClassConstantHandle Class)
    {

        /// <summary>
        /// Parses an interface.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="iface"></param>
        public static bool TryRead(ref ClassFormatReader reader, out Interface iface)
        {
            iface = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;

            iface = new Interface(new(classIndex));
            return true;
        }

    }

}
