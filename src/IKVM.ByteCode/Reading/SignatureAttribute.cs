namespace IKVM.ByteCode.Reading
{

    public readonly record struct SignatureAttribute(Utf8ConstantHandle Signature)
    {

        public static SignatureAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SignatureAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort signatureIndex) == false)
                return false;

            attribute = new SignatureAttribute(new Utf8ConstantHandle(signatureIndex));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}