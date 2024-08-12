using System;

namespace IKVM.ByteCode
{

    public static partial class OpCodeExtensions
    {

        /// <summary>
        /// Gets the size of the byte code offset operand for the given branch instruction.
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static partial byte GetBranchOperandSize(this OpCode opcode);

    }

}
