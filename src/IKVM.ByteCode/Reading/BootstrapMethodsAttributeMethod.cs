using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct BootstrapMethodsAttributeMethod(MethodHandleConstantHandle Method, ReadOnlyMemory<ConstantHandle> Arguments)
    {

        public static bool TryRead(ref ClassFormatReader reader, out BootstrapMethodsAttributeMethod method)
        {
            method = default;

            if (reader.TryReadU2(out ushort methodIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort argumentCount) == false)
                return false;

            var arguments = new ConstantHandle[argumentCount];
            for (int i = 0; i < argumentCount; i++)
            {
                if (reader.TryReadU2(out ushort argumentIndex) == false)
                    return false;

                arguments[i] = new(ConstantKind.Unknown, argumentIndex);
            }

            method = new BootstrapMethodsAttributeMethod(new(methodIndex), arguments);
            return true;
        }

    }

}
