namespace IKVM.ByteCode.Parsing
{

    internal sealed record ModuleMainClassAttributeRecord(ClassConstantHandle MainClassIndex) : AttributeRecord
    {

        public static bool TryReadModuleMainClassAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort mainClassIndex) == false)
                return false;

            attribute = new ModuleMainClassAttributeRecord(new ClassConstantHandle(mainClassIndex));
            return true;
        }

    }

}
