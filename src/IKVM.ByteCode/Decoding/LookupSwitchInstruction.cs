﻿using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LookupSwitchInstruction(int DefaultTarget, LookupSwitchCaseTable Cases)
    {

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LookupSwitch)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // advance by opcode size
            size += 1;

            // table structure is always aligned to 4 bytes
            var position = (int)reader.Consumed;
            if (reader.TryAlign(4) == false)
                return false;

            // how far we advanced
            size += (int)reader.Consumed - position;

            // default label is always 4 bytes
            size += 4;
            if (reader.TryAdvance(4) == false)
                return false;

            // npairs is always 4 bytes
            if (LookupSwitchCaseTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public static bool TryRead(ReadOnlySequence<byte> data, out LookupSwitchInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        internal static bool TryRead(ref SequenceReader<byte> reader, out LookupSwitchInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LookupSwitch)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // structure is always aligned to 4 bytes
            var p = reader.Position;
            if (reader.TryAlign(4) == false)
                return false;

            // default label is always 4 bytes
            if (reader.TryReadBigEndian(out int defaultTarget) == false)
                return false;

            // read matches into a table
            if (LookupSwitchCaseTable.TryRead(ref reader, out var matches) == false)
                return false;

            instruction = new LookupSwitchInstruction(defaultTarget, matches);
            return true;
        }

        /// <summary>
        /// Gets the offset of the default condition.
        /// </summary>
        public readonly int DefaultTarget = DefaultTarget;

        /// <summary>
        /// Gets the match table.
        /// </summary>
        public readonly LookupSwitchCaseTable Cases = Cases;

    }

}