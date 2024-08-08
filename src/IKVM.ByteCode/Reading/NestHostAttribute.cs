namespace IKVM.ByteCode.Reading
{

    public readonly record struct NestHostAttribute(ClassConstantHandle NestHost, bool IsNotNil = true)
    {

        public static NestHostAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out NestHostAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort hostClassIndex) == false)
                return false;

            attribute = new NestHostAttribute(new ClassConstantHandle(hostClassIndex));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
