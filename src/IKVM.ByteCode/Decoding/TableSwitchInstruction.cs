using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct TableSwitchInstruction(int Offset, int DefaultTarget, int Low, int High, TableSwitchMatchTable Matches)
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

            if (opcode != OpCode.TableSwitch)
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

            // low value is always 4 bytes
            size += 4;
            if (reader.TryReadBigEndian(out int low) == false)
                return false;

            // high value is always 4 bytes
            size += 4;
            if (reader.TryReadBigEndian(out int high) == false)
                return false;

            if (high < low)
                throw new InvalidClassException("High cannot be less than low.");

            // size of resulting table
            if (TableSwitchMatchTable.TryMeasure(ref reader, high - low + 1, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public static bool TryRead(ref SequenceReader<byte> reader, out TableSwitchInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.TableSwitch)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // table structure is always aligned to 4 bytes
            var p = reader.Position;
            if (reader.TryAlign(4) == false)
                return false;

            // default label is always 4 bytes
            if (reader.TryReadBigEndian(out int defaultTarget) == false)
                return false;

            // low value is always 4 bytes
            if (reader.TryReadBigEndian(out int low) == false)
                return false;

            // high value is always 4 bytes
            if (reader.TryReadBigEndian(out int high) == false)
                return false;

            if (high < low)
                throw new InvalidClassException("High cannot be less than low.");

            // low value is always 4 bytes
            if (TableSwitchMatchTable.TryRead(ref reader, high - low + 1, out var matches) == false)
                return false;

            instruction = new TableSwitchInstruction(position.GetInteger(), defaultTarget, low, high, matches);
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
        /// Gets the value of the Low match.
        /// </summary>
        public readonly int Low = Low;

        /// <summary>
        /// Gets the value of the High match.
        /// </summary>
        public readonly int High = High;

        /// <summary>
        /// Gets the table of matches.
        /// </summary>
        public readonly TableSwitchMatchTable Matches = Matches;

    }

}