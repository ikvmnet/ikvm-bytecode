using System;

namespace IKVM.ByteCode
{

    public static class OpCodeExtensions
    {

        /// <summary>
        /// Gets the size of the byte code offset operand for the given branch instruction.
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static byte GetBranchOperandSize(this OpCode opcode)
        {
            switch (opcode)
            {
                case OpCode._goto:
                case OpCode._if_acmpeq:
                case OpCode._if_acmpne:
                case OpCode._if_icmpeq:
                case OpCode._if_icmpne:
                case OpCode._if_icmpge:
                case OpCode._if_icmpgt:
                case OpCode._if_icmple:
                case OpCode._if_icmplt:
                case OpCode._ifeq:
                case OpCode._ifne:
                case OpCode._iflt:
                case OpCode._ifge:
                case OpCode._ifgt:
                case OpCode._ifle:
                case OpCode._ifnonnull:
                case OpCode._ifnull:
                case OpCode._jsr:
                    return 2;
                case OpCode._goto_w:
                case OpCode._jsr_w:
                    return 4;
                default:
                    throw new ArgumentException("Unexpected opcode.", nameof(opcode));
            }
        }

    }

}
