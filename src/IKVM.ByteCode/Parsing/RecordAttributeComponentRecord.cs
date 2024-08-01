namespace IKVM.ByteCode.Parsing
{

    public readonly record struct RecordAttributeComponentRecord(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeInfoRecord[] Attributes);

}
