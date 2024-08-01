namespace IKVM.ByteCode.Parsing
{

    public readonly record struct BootstrapMethodsAttributeMethodRecord(MethodHandleConstantHandle Method, ConstantHandle[] Arguments)
    {

        public static bool TryReadBootstrapMethod(ref ClassFormatReader reader, out BootstrapMethodsAttributeMethodRecord method)
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

                arguments[i] = new(argumentIndex);
            }

            method = new BootstrapMethodsAttributeMethodRecord(new(methodIndex), arguments);
            return true;
        }

    }

}
