namespace IKVM.ByteCode.Reading
{

    public readonly record struct EnclosingMethodAttribute(ClassConstantHandle Class, NameAndTypeConstantHandle Method)
    {

        public static EnclosingMethodAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out EnclosingMethodAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort methodIndex) == false)
                return false;

            attribute = new EnclosingMethodAttribute(new(classIndex), new(methodIndex));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
