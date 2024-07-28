namespace IKVM.ByteCode.Parsing
{

    internal record struct RecordAttributeComponentRecord(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeInfoRecord[] Attributes);

}
