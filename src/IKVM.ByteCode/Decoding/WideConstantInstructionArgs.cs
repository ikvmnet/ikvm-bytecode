using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct WideConstantInstructionArgs(ConstantHandle Arg1)
    {

        public static bool TryRead(ref SequenceReader<byte> reader, OpCode opcode, out WideConstantInstructionArgs value)
        {
            value = default;

            if (reader.TryReadBigEndian(out ushort arg1) == false)
                return false;

            value = new WideConstantInstructionArgs(new ConstantHandle(ConstantKind.Unknown, arg1));
            return true;
        }

        public readonly ConstantHandle Arg1 = Arg1;

    }

}
