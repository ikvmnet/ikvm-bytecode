namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleRequireInfo(ModuleConstantHandle Module, ModuleRequiresFlag Flag, Utf8ConstantHandle Version);

}