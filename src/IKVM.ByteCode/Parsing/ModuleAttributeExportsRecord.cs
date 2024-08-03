namespace IKVM.ByteCode.Parsing
{

    public readonly record struct ModuleAttributeExportsRecord(PackageConstantHandle Package, ModuleExportsFlag Flags, ModuleConstantHandle[] Modules);

}
