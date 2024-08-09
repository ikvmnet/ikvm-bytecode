namespace IKVM.ByteCode.Reading
{

    public readonly record struct DeprecatedAttribute()
    {

        public static DeprecatedAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out DeprecatedAttribute attribute)
        {
            attribute = new DeprecatedAttribute();
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}