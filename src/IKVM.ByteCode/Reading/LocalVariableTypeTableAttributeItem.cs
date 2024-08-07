namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariableTypeTableAttributeItem(ushort CodeOffset, ushort CodeLength, Utf8ConstantHandle Name, Utf8ConstantHandle Signature, ushort Index);

}
