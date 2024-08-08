using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct NestMembersAttribute(ClassConstantHandleTable NestMembers, bool IsNotNil = true)
    {

        public static NestMembersAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out NestMembersAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var classes = count == 0 ? [] : new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort classIndex) == false)
                    return false;

                classes[i] = new(classIndex);
            }

            attribute = new NestMembersAttribute(new(classes));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
