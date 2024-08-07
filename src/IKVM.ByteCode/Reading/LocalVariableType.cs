namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariableType(ushort CodeOffset, ushort CodeLength, Utf8ConstantHandle Name, Utf8ConstantHandle Signature, ushort Index);

}
