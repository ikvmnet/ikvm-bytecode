namespace IKVM.ByteCode.Reading
{

    public readonly record struct ConstantValueAttribute(ConstantHandle Value)
    {

        public static ConstantValueAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ConstantValueAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort valueIndex) == false)
                return false;

            attribute = new ConstantValueAttribute(new ConstantHandle(ConstantKind.Unknown, valueIndex));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
