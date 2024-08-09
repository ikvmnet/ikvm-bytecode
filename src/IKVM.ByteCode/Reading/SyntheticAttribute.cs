namespace IKVM.ByteCode.Reading
{

    public readonly record struct SyntheticAttribute()
    {

        public static SyntheticAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SyntheticAttribute attribute)
        {
            attribute = new SyntheticAttribute();
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
