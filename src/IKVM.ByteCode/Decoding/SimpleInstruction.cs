using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct SimpleInstruction(OpCode OpCode)
    {

        public static bool TryRead(ref SequenceReader<byte> reader, OpCode opcode, out SimpleInstruction value)
        {
            value = new SimpleInstruction(opcode);
            return true;
        }

        public readonly OpCode OpCode = OpCode;

    }

}
