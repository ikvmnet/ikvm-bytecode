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
        /// The dependence causes any module which depends on the <i>current module</i> to have an implicitly
        /// declared dependence on the module named by the <c>Requires</c>.
        /// </summary>
        Transitive = AccessFlag.Transitive,

        /// <summary>
        /// The dependence is mandatory in the static phase, during compilation, but is optional in the dynamic
        /// phase, during execution.
        /// </summary>
        Static = AccessFlag.StaticPhase,

        /// <summary>
        /// The dependence was not explicitly or implicitly declared in the source of the module declaration.
        /// </summary>
        Synthetic = AccessFlag.Synthetic,

        /// <summary>
        /// The dependence was implicitly declared in the source of the module declaration.
        /// </summary>
        Mandated = AccessFlag.Mandated,

    }

}