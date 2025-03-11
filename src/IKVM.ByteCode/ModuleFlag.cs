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
        /// An automatic module.
        /// </summary>
        Automatic = 0,

        /// <summary>
        /// The module was implicitly declared.
        /// </summary>
        Mandated = AccessFlag.Mandated,

        /// <summary>
        /// An open module.
        /// </summary>
        Open = AccessFlag.Open,

        /// <summary>
        /// The module was not explicitly or implicitly declared.
        /// </summary>
        Synthetic = AccessFlag.Synthetic,

    }

}