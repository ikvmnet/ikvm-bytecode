namespace IKVM.ByteCode.Reading
{

    public readonly record struct RecordAttribute(RecordComponentTable Components, bool IsNotNil = true)
    {

        public static RecordAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RecordAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort componentsCount) == false)
                return false;

            var components = componentsCount == 0 ? [] : new RecordComponent[componentsCount];
            for (int i = 0; i < componentsCount; i++)
            {
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort descriptorIndex) == false)
                    return false;
                if (ClassFile.TryReadAttributeTable(ref reader, out var attributes) == false)
                    return false;

                components[i] = new RecordComponent(new(nameIndex), new(descriptorIndex), attributes);
            }

            attribute = new RecordAttribute(new(components));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
