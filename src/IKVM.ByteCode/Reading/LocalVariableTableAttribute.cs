using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariableTableAttribute(ReadOnlyMemory<LocalVariableTableAttributeItem> Items, bool IsNotNil = true)
    {

        public static LocalVariableTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out LocalVariableTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var items = new LocalVariableTableAttributeItem[length];
            for (int i = 0; i < length; i++)
            {
                if (reader.TryReadU2(out ushort codeOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort codeLength) == false)
                    return false;
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort descriptorIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort index) == false)
                    return false;

                items[i] = new LocalVariableTableAttributeItem(codeOffset, codeLength, new(nameIndex), new(descriptorIndex), index);
            }

            attribute = new LocalVariableTableAttribute(items);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
