namespace IKVM.ByteCode.Parsing
{

    public sealed record TypeAndNameConstantRecord(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor) : ConstantRecord;

}
