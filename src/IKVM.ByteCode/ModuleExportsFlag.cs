using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// A modifier on an export package.
    /// </summary>
    [Flags]
    public enum ModuleExportsFlag : ushort
    {

        /// <summary>
        /// Indicates that this export was not explicitly or implicitly declared in the source of the module declaration.
        /// </summary>
        Synthetic = 0x1000,

        /// <summary>
        /// Indicates that this export was implicitly declared in the source of the module declaration.
        /// </summary>
        Mandated = 0x8000,

    }

}