namespace IKVM.ByteCode.Reading
{

    public readonly record struct DeprecatedAttribute(bool IsNotNil = true)
    {

        public static DeprecatedAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out DeprecatedAttribute attribute)
        {
            attribute = new DeprecatedAttribute();
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}