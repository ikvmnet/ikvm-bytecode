using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// A modifier on an open package.
    /// </summary>
    [Flags]
    public enum ModuleOpensFlag : ushort
    {

        /// <summary>
        /// The open package was not explicitly or implicitly declared in the source of the module declaration.
        /// </summary>
        Synthetic = AccessFlag.Synthetic,

        /// <summary>
        /// The open package was implicitly declared in the source of the module declaration.
        /// </summary>
        Mandated = AccessFlag.Mandated,

    }

}
