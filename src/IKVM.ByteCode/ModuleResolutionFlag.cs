namespace IKVM.ByteCode
{

    /// <summary>
    /// Resolution flags for a module, as stored in the JDK-internal <c>ModuleResolution</c> attribute.
    /// </summary>
    public enum ModuleResolutionFlag : ushort
    {

        /// <summary>The module should not be resolved by default when the JVM starts up.</summary>
        DoNotResolveByDefault = 0x0001,

        /// <summary>A warning should be issued when the module is resolved because it is deprecated.</summary>
        WarnDeprecated = 0x0002,

        /// <summary>A warning should be issued when the module is resolved because it is deprecated for removal.</summary>
        WarnDeprecatedForRemoval = 0x0004,

        /// <summary>A warning should be issued when the module is resolved because it is an incubating module.</summary>
        WarnIncubating = 0x0008,

    }

}
