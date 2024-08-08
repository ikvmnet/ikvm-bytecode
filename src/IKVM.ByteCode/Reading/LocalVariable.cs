namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariable(ushort StartPc, ushort Length, Utf8ConstantHandle Name, Utf8ConstantHandle Type, ushort Slot);

}
