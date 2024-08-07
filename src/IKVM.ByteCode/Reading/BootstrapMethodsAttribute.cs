using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct BootstrapMethodsAttribute(ReadOnlyMemory<BootstrapMethodsAttributeMethod> Methods, bool IsNotNil = true)
    {

        public static BootstrapMethodsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out BootstrapMethodsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var methods = new BootstrapMethodsAttributeMethod[count];
            for (int i = 0; i < count; i++)
            {
                if (BootstrapMethodsAttributeMethod.TryRead(ref reader, out var method) == false)
                    return false;

                methods[i] = method;
            }

            attribute = new BootstrapMethodsAttribute(methods);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
