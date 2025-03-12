using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// A modifier on a module dependence.
    /// </summary>
    [Flags]
    public enum ModuleRequiresFlag : ushort
    {

        /// <summary>
        /// Indicates that any module which depends on the current module, implicitly declares a dependence on the module indicated by this entry.
        /// </summary>
        Transitive = AccessFlag.Transitive,

        /// <summary>
        /// Indicates that this dependence is mandatory in the static phase, i.e., at compile time, but is optional in the dynamic phase, i.e., at run time.
        /// </summary>
        StaticPhase = AccessFlag.StaticPhase,

        /// <summary>
        /// Indicates that this dependence was not explicitly or implicitly declared in the source of the module declaration.
        /// </summary>
        Synthetic = AccessFlag.Synthetic,

        /// <summary>
        /// Indicates that this dependence was implicitly declared in the source of the module declaration.
        /// </summary>
        Mandated = AccessFlag.Mandated,

    }

}