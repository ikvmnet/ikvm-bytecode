using System;
using System.Buffers;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a single instruction within a code block.
    /// </summary>
    /// <param name="Position"></param>
    /// <param name="OpCode"></param>
    /// <param name="IsWide"></param>
    /// <param name="Data"></param>
    public readonly partial record struct Instruction(SequencePosition Position, OpCode OpCode, bool IsWide, ReadOnlySequence<byte> Data)
    {

        internal static bool TryMeasureU1(ref SequenceReader<byte> reader, ref int size)
        {
            size += 1;
            return true;
        }

        internal static bool TryMeasureU2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            return true;
        }

        internal static bool TryMeasureS1(ref SequenceReader<byte> reader, ref int size)
        {
            size += 1;
            return true;
        }

        internal static bool TryMeasureS2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            return true;
        }

        internal static bool TryMeasureC1(ref SequenceReader<byte> reader, ref int size)
        {
            size += 1;
            return true;
        }

        internal static bool TryMeasureC2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            return true;
        }

        internal static bool TryMeasureL1(ref SequenceReader<byte> reader, ref int size)
        {
            size += 1;
            return true;
        }

        internal static bool TryMeasureL2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            return true;
        }

        internal static bool TryMeasureJ2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            return true;
        }

        internal static bool TryMeasureJ4(ref SequenceReader<byte> reader, ref int size)
        {
            size += 4;
            return true;
        }

        internal static bool TryReadU1(ref SequenceReader<byte> reader, out byte handle)
        {
            handle = default;

            if (reader.TryRead(out byte value) == false)
                return false;

            handle = value;
            return true;
        }

        internal static bool TryReadU2(ref SequenceReader<byte> reader, out ushort handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out ushort value) == false)
                return false;

            handle = value;
            return true;
        }

        internal static bool TryReadS1(ref SequenceReader<byte> reader, out sbyte handle)
        {
            handle = default;

            if (reader.TryRead(out sbyte value) == false)
                return false;

            handle = value;
            return true;
        }

        internal static bool TryReadS2(ref SequenceReader<byte> reader, out short handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out short value) == false)
                return false;

            handle = value;
            return true;
        }

        internal static bool TryReadC1(ref SequenceReader<byte> reader, out ConstantHandle handle)
        {
            handle = default;

            if (reader.TryRead(out byte value) == false)
                return false;

            handle = new ConstantHandle(ConstantKind.Unknown, value);
            return true;
        }

        internal static bool TryReadC2(ref SequenceReader<byte> reader, out ConstantHandle handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out ushort value) == false)
                return false;

            handle = new ConstantHandle(ConstantKind.Unknown, value);
            return true;
        }

        internal static bool TryReadL1(ref SequenceReader<byte> reader, out byte handle)
        {
            handle = default;

            if (reader.TryRead(out byte value) == false)
                return false;

            handle = value;
            return true;
        }

        internal static bool TryReadL2(ref SequenceReader<byte> reader, out ushort handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out ushort value) == false)
                return false;

            handle = value;
            return true;
        }

        internal static bool TryReadJ2(ref SequenceReader<byte> reader, out short handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out short value) == false)
                return false;

            handle = value;
            return true;
        }

        internal static bool TryReadJ4(ref SequenceReader<byte> reader, out int handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out int value) == false)
                return false;

            handle = value;
            return true;
        }

        /// <summary>
        /// Attempts to peek at the next opcode.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="opcode"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryPeekOpCode(ref SequenceReader<byte> reader, out OpCode opcode, out bool wide)
        {
            opcode = default;
            wide = false;

            // must have at least one byte
            if (reader.Length == 0)
                return false;

            // first instruction
            if (reader.TryPeek(out var opcodeByte) == false)
                return false;

            if (Enum.IsDefined(typeof(OpCode), opcodeByte) == false)
                throw new ByteCodeException($"OpCode {opcodeByte:XX} at current position {reader.Position} is not known.");

            // opcode is first byte, if it's WIDE, we need to actually read ahead and then rewind
            opcode = (OpCode)opcodeByte;
            if (opcode == OpCode.Wide)
            {
                // record starting position of instruction for rewind
                var position = reader.Position;
                wide = true;

                // we previously just peeked, need to advance over
                if (reader.TryAdvance(1) == false)
                    return false;

                // read next opcode, which is modified opcode
                if (reader.TryRead(out opcodeByte) == false)
                    return false;

                if (Enum.IsDefined(typeof(Instruction), opcodeByte) == false)
                    throw new ByteCodeException($"OpCode {opcodeByte:XX} at current position {position} is not known.");

                opcode = (OpCode)opcodeByte;
                reader.Rewind(reader.Position.GetInteger() - position.GetInteger());
            }

            return true;
        }

        /// <summary>
        /// Attempts to peek at the next opcode.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="opcode"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadOpCode(ref SequenceReader<byte> reader, out OpCode opcode, out bool wide)
        {
            opcode = default;
            wide = false;

            // must have at least one byte
            if (reader.Length == 0)
                return false;

            // first instruction
            if (reader.TryRead(out var opcodeByte) == false)
                return false;

            if (Enum.IsDefined(typeof(OpCode), opcodeByte) == false)
                throw new ByteCodeException($"OpCode {opcodeByte:XX} at current position {reader.Position} is not known.");

            // opcode is first byte, if it's WIDE, we need to actually read ahead and then rewind
            opcode = (OpCode)opcodeByte;
            if (opcode == OpCode.Wide)
            {
                // record starting position of instruction for rewind
                var position = reader.Position;
                wide = true;

                // read next opcode, which is modified opcode
                if (reader.TryRead(out opcodeByte) == false)
                    return false;

                if (Enum.IsDefined(typeof(Instruction), opcodeByte) == false)
                    throw new ByteCodeException($"OpCode {opcodeByte:XX} at current position {reader.Position} is not known.");
                if (opcode == OpCode.Wide)
                    throw new ByteCodeException($"A 'wide' opcode prefix cannot follow a previous 'wide' opcode prefix.");

                opcode = (OpCode)opcodeByte;
            }

            return true;
        }

        /// <summary>
        /// Attempts to measure the instruction at the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            // peek at the opcode so we can determine which instruction to dispatch to
            if (TryPeekOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            // dispatch to instruction
            if (TryMeasureInstruction(ref reader, opcode, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the instruction at the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Instruction instruction)
        {
            instruction = default;

            // peek at the opcode information to include it in the output instruction
            if (TryPeekOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            // first measure the size of the instruction
            int size = 0;
            if (TryMeasure(ref reader, ref size) == false)
                return false;

            // then read the entire instruction contents
            if (reader.TryReadExact(size, out var data) == false)
                return false;

            instruction = new Instruction(reader.Position, opcode, wide, data);
            return true;
        }

        /// <summary>
        /// Gets the offset of this instruction within a larger block of code.
        /// </summary>
        public readonly SequencePosition Position = Position;

        /// <summary>
        /// Gets the <see cref="OpCode"/> that makes up the instruction.
        /// </summary>
        public readonly OpCode OpCode = OpCode;

        /// <summary>
        /// Gets whether the instruction has the 'wide' prefix applied.
        /// </summary>
        /// <returns></returns>
        public readonly bool IsWide = IsWide;

        /// <summary>
        /// Gets the underlying data of the instruction.
        /// </summary>
        public readonly ReadOnlySequence<byte> Data = Data;

    }

}
