using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct RecordAttributeComponent(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeTable Attributes);

}
