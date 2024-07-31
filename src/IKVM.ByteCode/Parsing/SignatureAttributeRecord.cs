namespace IKVM.ByteCode.Parsing
{

    public record SignatureAttributeRecord(Utf8ConstantHandle Signature) : AttributeRecord
    {

        public static bool TryReadSignatureAttribute(ref ClassFormatReader reader, out AttributeRecord attribute)
        {
            attribute = null;

            if (reader.TryReadU2(out ushort signatureIndex) == false)
                return false;

            attribute = new SignatureAttributeRecord(new Utf8ConstantHandle(signatureIndex));
            return true;
        }

    }

}