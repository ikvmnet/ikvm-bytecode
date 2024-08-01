namespace IKVM.ByteCode.Parsing
{

    public readonly record struct ModuleAttributeExportsRecord(ushort Index, ModuleExportsFlag Flags, ushort[] Modules);

}
