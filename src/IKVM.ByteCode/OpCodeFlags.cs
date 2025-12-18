using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Describes various attributes of an opcode.
    /// </summary>
    [Flags]
    public enum OpCodeFlags : byte
    {

        /// <summary>
        /// No additional flags.
        /// </summary>
        None = 0,

        /// <summary>
        /// Instructions using the opcode cannot throw an exception.
        /// </summary>
        CannotThrow = 2,

    }

}
