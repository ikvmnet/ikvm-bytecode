using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct MethodParametersAttribute(ReadOnlyMemory<MethodParametersAttributeParameter> Parameters, bool IsNotNil = true)
    {

        public static MethodParametersAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out MethodParametersAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU1(out byte count) == false)
                return false;

            var arguments = new MethodParametersAttributeParameter[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort accessFlags) == false)
                    return false;

                arguments[i] = new MethodParametersAttributeParameter(new(nameIndex), (AccessFlag)accessFlags);
            }

            attribute = new MethodParametersAttribute(arguments);
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
