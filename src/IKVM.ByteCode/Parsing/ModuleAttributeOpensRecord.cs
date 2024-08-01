namespace IKVM.ByteCode.Parsing
{

    public readonly record struct ModuleAttributeOpensRecord(ushort Index, ModuleOpensFlag Flags, ushort[] Modules);

}
