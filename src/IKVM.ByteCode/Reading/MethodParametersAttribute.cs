namespace IKVM.ByteCode.Reading
{

    public readonly record struct MethodParametersAttribute(MethodParameterTable Parameters)
    {

        public static MethodParametersAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out MethodParametersAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU1(out byte count) == false)
                return false;

            var arguments = count == 0 ? [] : new MethodParameter[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort accessFlags) == false)
                    return false;

                arguments[i] = new MethodParameter(new(nameIndex), (AccessFlag)accessFlags);
            }

            attribute = new MethodParametersAttribute(new(arguments));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
