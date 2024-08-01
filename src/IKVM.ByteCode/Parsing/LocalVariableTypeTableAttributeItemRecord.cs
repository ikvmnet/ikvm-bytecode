namespace IKVM.ByteCode.Parsing
{

    public readonly record struct LocalVariableTypeTableAttributeItemRecord(ushort CodeOffset, ushort CodeLength, Utf8ConstantHandle Name, Utf8ConstantHandle Signature, ushort Index);

}
