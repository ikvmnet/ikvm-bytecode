namespace IKVM.ByteCode.Parsing
{

    public record struct LocalVariableTypeTableAttributeItemRecord(ushort CodeOffset, ushort CodeLength, Utf8ConstantHandle Name, Utf8ConstantHandle Signature, ushort Index);

}
