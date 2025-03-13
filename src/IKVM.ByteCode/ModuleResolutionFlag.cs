namespace IKVM.ByteCode
{

    public enum ModuleResolutionFlag : ushort
    {

        DoNotResolveByDefault = 0x0001,

        WarnDeprecated = 0x0002,

        WarnDeprecatedForRemoval = 0x0004,

        WarnIncubating = 0x0008,

    }

}
