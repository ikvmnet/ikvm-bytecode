using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// A modifier on a module.
    /// </summary>
    [Flags]
    public enum ModuleFlag : ushort
    {

        /// <summary>
        /// Indicates that this module was implicitly declared.
        /// </summary>
        Mandated = AccessFlag.Mandated,

        /// <summary>
        /// Indicates that this module is open.
        /// </summary>
        Open = AccessFlag.Open,

        /// <summary>
        /// Indicates that this module was not explicitly or implicitly declared.
        /// </summary>
        Synthetic = AccessFlag.Synthetic,

    }

}