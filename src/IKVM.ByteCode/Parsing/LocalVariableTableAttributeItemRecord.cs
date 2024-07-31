namespace IKVM.ByteCode.Parsing
{

    public record struct LocalVariableTableAttributeItemRecord(ushort CodeOffset, ushort CodeLength, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, ushort Index);

}
