namespace IKVM.ByteCode.Parsing
{

    public record struct RecordAttributeComponentRecord(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeInfoRecord[] Attributes);

}
