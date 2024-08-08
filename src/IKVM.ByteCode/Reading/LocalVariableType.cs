namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariableType(ushort StartPc, ushort Length, Utf8ConstantHandle Name, Utf8ConstantHandle Signature, ushort Slot);

}
