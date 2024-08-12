using System;

namespace IKVM.ByteCode
{

    public static partial class OpCodeExtensions
    {

        public static partial byte GetBranchOperandSize(this OpCode opcode)
        {
            switch (opcode)
            {
                case OpCode.Ifeq:
                case OpCode.Ifne:
                case OpCode.Iflt:
                case OpCode.Ifge:
                case OpCode.Ifgt:
                case OpCode.Ifle:
                case OpCode.IfIcmpeq:
                case OpCode.IfIcmpne:
                case OpCode.IfIcmplt:
                case OpCode.IfIcmpge:
                case OpCode.IfIcmpgt:
                case OpCode.IfIcmple:
                case OpCode.IfAcmpeq:
                case OpCode.IfAcmpne:
                case OpCode.Goto:
                case OpCode.Jsr:
                case OpCode.Ifnull:
                case OpCode.Ifnonnull:
                    return 2;
                case OpCode.GotoW:
                case OpCode.JsrW:
                    return 4;
                default:
                    throw new ArgumentException("Unexpected opcode.", nameof(opcode));
            }
        }

    }

}
