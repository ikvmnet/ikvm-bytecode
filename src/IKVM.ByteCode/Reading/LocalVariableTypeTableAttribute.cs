using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariableTypeTableAttribute(ReadOnlyMemory<LocalVariableTypeTableAttributeItem> Items, bool IsNotNil = true)
    {

        public static LocalVariableTypeTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out LocalVariableTypeTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var items = new LocalVariableTypeTableAttributeItem[length];
            for (int i = 0; i < length; i++)
            {
                if (reader.TryReadU2(out ushort codeOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort codeLength) == false)
                    return false;
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort signatureIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort index) == false)
                    return false;

                items[i] = new LocalVariableTypeTableAttributeItem(codeOffset, codeLength, new(nameIndex), new(signatureIndex), index);
            }

            attribute = new LocalVariableTypeTableAttribute(items);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
