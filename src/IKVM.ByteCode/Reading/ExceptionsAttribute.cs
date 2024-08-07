﻿namespace IKVM.ByteCode.Reading
{

    public readonly record struct ExceptionsAttribute(ClassConstantHandleTable Exceptions, bool IsNotNil = true)
    {

        public static ExceptionsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ExceptionsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var entries = count == 0 ? [] : new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort index) == false)
                    return false;

                entries[i] = new(index);
            }

            attribute = new ExceptionsAttribute(new(entries));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}