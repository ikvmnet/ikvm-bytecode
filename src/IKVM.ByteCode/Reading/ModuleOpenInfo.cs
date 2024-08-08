namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleOpenInfo(PackageConstantHandle Package, ModuleOpensFlag Flags, ModuleConstantHandleTable Modules);

}
