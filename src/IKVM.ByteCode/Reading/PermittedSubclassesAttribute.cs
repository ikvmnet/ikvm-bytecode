using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct PermittedSubclassesAttribute(ReadOnlyMemory<ClassConstantHandle> ClassIndexes, bool IsNotNil = true)
    {

        public static PermittedSubclassesAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out PermittedSubclassesAttribute attribute)
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

            attribute = new PermittedSubclassesAttribute(classes);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
