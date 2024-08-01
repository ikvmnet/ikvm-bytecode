namespace IKVM.ByteCode.Parsing
{

    public readonly record struct ModuleAttributeRequiresRecord(ushort Index, ModuleRequiresFlag Flag, ushort VersionIndex);

}