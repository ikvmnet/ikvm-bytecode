namespace IKVM.ByteCode.Reading
{

    public readonly record struct SyntheticAttribute(bool IsNotNil = true)
    {

        public static SyntheticAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SyntheticAttribute attribute, bool IsNotNil = true)
        {
            attribute = new SyntheticAttribute();
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
