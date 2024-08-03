namespace IKVM.ByteCode.Parsing
{

    public readonly record struct ModuleAttributeOpensRecord(PackageConstantHandle Package, ModuleOpensFlag Flags, ModuleConstantHandle[] Modules);

}
