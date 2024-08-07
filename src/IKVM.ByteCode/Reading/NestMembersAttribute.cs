using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct NestMembersAttribute(ReadOnlyMemory<ClassConstantHandle> ClassIndexes, bool IsNotNil = true)
    {

        public static NestMembersAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out NestMembersAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var classes = new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort classIndex) == false)
                    return false;

                classes[i] = new(classIndex);
            }

            attribute = new NestMembersAttribute(classes);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
