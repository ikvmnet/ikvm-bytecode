using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct RecordAttribute(ReadOnlyMemory<RecordAttributeComponent> Components, bool IsNotNil = true)
    {

        public static RecordAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RecordAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort componentsCount) == false)
                return false;

            var components = new RecordAttributeComponent[componentsCount];
            for (int i = 0; i < componentsCount; i++)
            {
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort descriptorIndex) == false)
                    return false;
                if (ClassFile.TryReadAttributeTable(ref reader, out var attributes) == false)
                    return false;

                components[i] = new RecordAttributeComponent(new(nameIndex), new(descriptorIndex), attributes);
            }

            attribute = new RecordAttribute(components);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
