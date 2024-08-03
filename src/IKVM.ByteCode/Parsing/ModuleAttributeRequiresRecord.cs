namespace IKVM.ByteCode.Parsing
{

    public readonly record struct ModuleAttributeRequiresRecord(ModuleConstantHandle Module, ModuleRequiresFlag Flag, Utf8ConstantHandle Version);

}