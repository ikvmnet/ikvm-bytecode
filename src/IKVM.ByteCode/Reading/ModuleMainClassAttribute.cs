namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleMainClassAttribute(ClassConstantHandle MainClass)
    {

        public static ModuleMainClassAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ModuleMainClassAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort mainClassIndex) == false)
                return false;

            attribute = new ModuleMainClassAttribute(new ClassConstantHandle(mainClassIndex));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
