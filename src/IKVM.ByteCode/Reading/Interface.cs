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

        public readonly ClassConstantHandle Class = Class;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
