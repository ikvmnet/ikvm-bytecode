namespace IKVM.ByteCode.Reading
{

    public readonly record struct BootstrapMethod(MethodHandleConstantHandle Method, ConstantHandleTable Arguments)
    {

        public static bool TryRead(ref ClassFormatReader reader, out BootstrapMethod method)
        {
            method = default;

            if (reader.TryReadU2(out ushort methodIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort argumentCount) == false)
                return false;

            var arguments = argumentCount == 0 ? [] : new ConstantHandle[argumentCount];
            for (int i = 0; i < argumentCount; i++)
            {
                if (reader.TryReadU2(out ushort argumentIndex) == false)
                    return false;

                arguments[i] = new(ConstantKind.Unknown, argumentIndex);
            }

            method = new BootstrapMethod(new(methodIndex), new(arguments));
            return true;
        }

    }

}
