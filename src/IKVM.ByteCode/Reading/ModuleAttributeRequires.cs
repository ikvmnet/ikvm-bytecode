namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleAttributeRequires(ModuleConstantHandle Module, ModuleRequiresFlag Flag, Utf8ConstantHandle Version);

}