using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LookupSwitchInstruction(int Offset, int DefaultTarget, LookupSwitchMatchTable Matches)
    {

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LookupSwitch)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // advance by opcode size
            size += 1;

            // table structure is always aligned to 4 bytes
            var p = reader.Position;
            if (reader.TryAlign(4) == false)
                return false;

            // how far we advanced
            size += reader.Position.GetInteger() - p.GetInteger();

            // default label is always 4 bytes
            size += 4;
            if (reader.TryAdvance(4) == false)
                return false;

            // npairs is always 4 bytes
            if (LookupSwitchMatchTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public static bool TryRead(ref SequenceReader<byte> reader, out LookupSwitchInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LookupSwitch)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // structure is always aligned to 4 bytes
            var p = reader.Position;
            if (reader.TryAlign(4) == false)
                return false;

            // default label is always 4 bytes
            if (reader.TryReadBigEndian(out int defaultTarget) == false)
                return false;

            // read matches into a table
            if (LookupSwitchMatchTable.TryRead(ref reader, out var matches) == false)
                return false;

            instruction = new LookupSwitchInstruction(position.GetInteger(), defaultTarget, matches);
            return true;
        }

        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        /// <summary>
        /// Gets the offset of the default condition.
        /// </summary>
        public readonly int DefaultTarget = DefaultTarget;

        /// <summary>
        /// Gets the match table.
        /// </summary>
        public readonly LookupSwitchMatchTable Matches = Matches;

    }

}