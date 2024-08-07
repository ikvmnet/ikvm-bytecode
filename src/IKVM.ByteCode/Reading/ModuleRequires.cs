namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleRequires(ModuleConstantHandle Module, ModuleRequiresFlag Flag, Utf8ConstantHandle Version);

}