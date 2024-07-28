namespace IKVM.ByteCode.Parsing
{

    internal sealed record TypeAndNameConstantRecord(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor) : ConstantRecord;

}
