using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariableTableAttribute(LocalVariableTable Table, bool IsNotNil = true)
    {

        public static LocalVariableTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out LocalVariableTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var items = length == 0 ? [] : new LocalVariable[length];
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

                items[i] = new LocalVariable(codeOffset, codeLength, new(nameIndex), new(descriptorIndex), index);
            }

            attribute = new LocalVariableTableAttribute(new(items));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
