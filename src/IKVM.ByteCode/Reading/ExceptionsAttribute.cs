using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ExceptionsAttribute(ReadOnlyMemory<ClassConstantHandle> Exceptions, bool IsNotNil = true)
    {

        public static ExceptionsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ExceptionsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var entries = new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort index) == false)
                    return false;

                entries[i] = new(index);
            }

            attribute = new ExceptionsAttribute(entries);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}