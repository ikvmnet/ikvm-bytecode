namespace IKVM.ByteCode.Reading
{

    public readonly record struct SignatureAttribute(Utf8ConstantHandle Signature, bool IsNotNil = true)
    {

        public static SignatureAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SignatureAttribute attribute, bool IsNotNil = true)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort signatureIndex) == false)
                return false;

            attribute = new SignatureAttribute(new Utf8ConstantHandle(signatureIndex));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}