using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct InnerClassesAttribute(ReadOnlyMemory<InnerClassesAttributeItem> Items, bool IsNotNil = true)
    {

        public static InnerClassesAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out InnerClassesAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var items = new InnerClassesAttributeItem[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort innerClassInfoIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort outerClassInfoIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort innerNameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort innerClassAccessFlags) == false)
                    return false;

                items[i] = new InnerClassesAttributeItem(new(innerClassInfoIndex), new(outerClassInfoIndex), new(innerNameIndex), (AccessFlag)innerClassAccessFlags);
            }

            attribute = new InnerClassesAttribute(items);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
