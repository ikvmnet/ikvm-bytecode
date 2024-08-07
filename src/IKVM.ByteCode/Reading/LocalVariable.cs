namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariable(ushort CodeOffset, ushort CodeLength, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, ushort Index);

}
