namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariableTableAttributeItem(ushort CodeOffset, ushort CodeLength, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, ushort Index);

}
