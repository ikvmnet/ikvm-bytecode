using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct BootstrapMethodsAttribute(BootstrapMethodTable Methods, bool IsNotNil = true)
    {

        public static BootstrapMethodsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out BootstrapMethodsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var methods = count == 0 ? [] : new BootstrapMethod[count];
            for (int i = 0; i < count; i++)
            {
                if (BootstrapMethod.TryRead(ref reader, out var method) == false)
                    return false;

                methods[i] = method;
            }

            attribute = new BootstrapMethodsAttribute(new(methods));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
