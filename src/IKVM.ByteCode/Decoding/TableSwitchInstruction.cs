using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct TableSwitchInstruction(int DefaultTarget, int Low, int High, TableSwitchCaseTable Cases)
    {

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static bool TryMeasure(ref SequenceReader<byte> reader, int offset, ref int size)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.TableSwitch)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // advance by opcode size
            size += 1;

            // table structure is always aligned to 4 bytes from the offset of this instruction
            while ((offset + size) % 4 > 0)
            {
                size += 1;
                if (reader.TryAdvance(1) == false)
                    return false;
            }

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

            if (low > high)
                throw new InvalidCodeException("Low cannot be greater than high.");
            if (high > 16384L + low)
                throw new InvalidCodeException("High exceeds maximum size.");

            // size of resulting table
            if (TableSwitchCaseTable.TryMeasure(ref reader, high - low + 1, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public static bool TryRead(ReadOnlySequence<byte> data, int offset, out TableSwitchInstruction instruction)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, offset, out instruction);
        }

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        internal static bool TryRead(ref SequenceReader<byte> reader, int offset, out TableSwitchInstruction instruction)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.TableSwitch)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // table structure is always aligned to 4 bytes from the offset of this instruction
            int size = 1;
            while ((offset + size) % 4 > 0)
            {
                size += 1;
                if (reader.TryAdvance(1) == false)
                    return false;
            }

            // default label is always 4 bytes
            if (reader.TryReadBigEndian(out int defaultTarget) == false)
                return false;

            // low value is always 4 bytes
            if (reader.TryReadBigEndian(out int low) == false)
                return false;

            // high value is always 4 bytes
            if (reader.TryReadBigEndian(out int high) == false)
                return false;

            if (low > high)
                throw new InvalidCodeException("Low cannot be greater than high.");
            if (high > 16384L + low)
                throw new InvalidCodeException("High exceeds maximum size.");

            // low value is always 4 bytes
            if (TableSwitchCaseTable.TryRead(ref reader, high - low + 1, out var cases) == false)
                return false;

            instruction = new TableSwitchInstruction(defaultTarget, low, high, cases);
            return true;
        }

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
        public readonly TableSwitchCaseTable Cases = Cases;

    }

}