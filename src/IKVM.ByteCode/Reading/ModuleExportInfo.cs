namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleExportInfo(PackageConstantHandle Package, ModuleExportsFlag Flags, ModuleConstantHandleTable Modules);

}
