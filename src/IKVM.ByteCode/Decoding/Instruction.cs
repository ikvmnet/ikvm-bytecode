﻿using System;
using System.Buffers;
using System.Runtime.CompilerServices;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a single instruction within a code block.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="OpCode"></param>
    /// <param name="IsWide"></param>
    /// <param name="Data"></param>
    public readonly partial record struct Instruction(int Offset, OpCode OpCode, bool IsWide, ReadOnlySequence<byte> Data)
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureU1(ref SequenceReader<byte> reader, ref int size)
        {
            size += 1;
            if (reader.TryAdvance(1) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureU2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            if (reader.TryAdvance(2) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureS1(ref SequenceReader<byte> reader, ref int size)
        {
            size += 1;
            if (reader.TryAdvance(1) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureS2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            if (reader.TryAdvance(2) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureC1(ref SequenceReader<byte> reader, ref int size)
        {
            size += 1;
            if (reader.TryAdvance(1) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureC2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            if (reader.TryAdvance(2) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureL1(ref SequenceReader<byte> reader, ref int size)
        {
            size += 1;
            if (reader.TryAdvance(1) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureL2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            if (reader.TryAdvance(2) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureJ2(ref SequenceReader<byte> reader, ref int size)
        {
            size += 2;
            if (reader.TryAdvance(2) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureJ4(ref SequenceReader<byte> reader, ref int size)
        {
            size += 4;
            if (reader.TryAdvance(4) == false)
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadU1(ref SequenceReader<byte> reader, out byte handle)
        {
            handle = default;

            if (reader.TryRead(out byte value) == false)
                return false;

            handle = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadU2(ref SequenceReader<byte> reader, out ushort handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out ushort value) == false)
                return false;

            handle = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadS1(ref SequenceReader<byte> reader, out sbyte handle)
        {
            handle = default;

            if (reader.TryRead(out sbyte value) == false)
                return false;

            handle = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadS2(ref SequenceReader<byte> reader, out short handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out short value) == false)
                return false;

            handle = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadC1(ref SequenceReader<byte> reader, out ConstantHandle handle)
        {
            handle = default;

            if (reader.TryRead(out byte value) == false)
                return false;

            handle = new ConstantHandle(ConstantKind.Unknown, value);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadC2(ref SequenceReader<byte> reader, out ConstantHandle handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out ushort value) == false)
                return false;

            handle = new ConstantHandle(ConstantKind.Unknown, value);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadL1(ref SequenceReader<byte> reader, out byte handle)
        {
            handle = default;

            if (reader.TryRead(out byte value) == false)
                return false;

            handle = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadL2(ref SequenceReader<byte> reader, out ushort handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out ushort value) == false)
                return false;

            handle = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryReadJ2(ref SequenceReader<byte> reader, out short handle)
        {
            handle = default;

            if (reader.TryReadBigEndian(out short value) == false)
                return false;

            handle = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        /// <param name="wide"></param>
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

            opcode = (OpCode)opcodeByte;
            if (opcode.IsValid() == false)
                throw new InvalidCodeException($"OpCode {opcodeByte:XX} at current position {reader.Position} is not known.");

            // opcode is first byte, if it's WIDE, we need to actually read ahead and then rewind
            if (opcode == OpCode.Wide)
            {
                // record starting position of instruction for rewind
                var position = (int)reader.Consumed;
                wide = true;

                // we previously just peeked, need to advance over
                if (reader.TryAdvance(1) == false)
                    return false;

                // read next opcode, which is modified opcode
                if (reader.TryRead(out opcodeByte) == false)
                    return false;

                opcode = (OpCode)opcodeByte;
                if (opcode.IsValid() == false)
                    throw new InvalidCodeException($"OpCode {opcodeByte:XX} at current position {position} is not known.");

                reader.Rewind(reader.Consumed - position);
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

            opcode = (OpCode)opcodeByte;
            if (opcode.IsValid() == false)
                throw new InvalidCodeException($"OpCode {opcodeByte:XX} at current position {reader.Position} is not known.");

            // opcode is first byte, if it's WIDE, we need to actually read ahead and then rewind
            if (opcode == OpCode.Wide)
            {
                // record starting position of instruction for rewind
                var position = reader.Position;
                wide = true;

                // read next opcode, which is modified opcode
                if (reader.TryRead(out opcodeByte) == false)
                    return false;

                opcode = (OpCode)opcodeByte;
                if (opcode.IsValid() == false)
                    throw new InvalidCodeException($"OpCode {opcodeByte:XX} at current position {reader.Position} is not known.");
                if (opcode == OpCode.Wide)
                    throw new InvalidCodeException($"A 'wide' opcode prefix cannot follow a previous 'wide' opcode prefix.");

                opcode = (OpCode)opcodeByte;
            }

            return true;
        }

        /// <summary>
        /// Attempts to measure the instruction at the current position.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref ReadOnlySequence<byte> data, int offset, ref int size)
        {
            var reader = new SequenceReader<byte>(data);
            return TryMeasure(ref reader, offset, ref size);
        }

        /// <summary>
        /// Attempts to measure the instruction at the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, int offset, ref int size)
        {
            // peek at the opcode so we can determine which instruction to dispatch to
            if (TryPeekOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            // dispatch to instruction
            if (TryMeasureInstruction(ref reader, opcode, offset, ref size) == false)
                throw new InvalidCodeException("End of data reached before completion of instruction.");

            return true;
        }

        /// <summary>
        /// Attempts to read the instruction at the current position.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="offset"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref ReadOnlySequence<byte> sequence, out Instruction instruction)
        {
            var reader = new SequenceReader<byte>(sequence);
            return TryRead(ref reader, out instruction);
        }

        /// <summary>
        /// Attempts to read the instruction at the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Instruction instruction)
        {
            var position = (int)reader.Consumed;
            instruction = default;

            // peek at the opcode information to include it in the output instruction
            if (TryPeekOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            // first measure the size of the instruction
            int size = 0;
            if (TryMeasure(ref reader, position, ref size) == false)
                return false;

            // rewind and capture all of the instruction data
            reader.Rewind(size);
            if (reader.TryReadExact(size, out var data) == false)
                return false;

            instruction = new Instruction(position, opcode, wide, data);
            return true;
        }

        /// <summary>
        /// Attempts to read the instruction at the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Instruction Read(ref SequenceReader<byte> reader)
        {
            // if we don't have an opcode, we have no instruction to read, so return nil
            if (TryPeekOpCode(ref reader, out _, out _) == false)
                return default;

            // we did have an opcode, so attempt to read the remainder, but fail if end reached
            if (TryRead(ref reader, out var instruction) == false)
                throw new InvalidCodeException("End of data reached before completion of instruction.");

            return instruction;
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether this instruction is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether this instruction is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Gets the offset of this instruction within a larger block of code.
        /// </summary>
        public readonly int Offset = Offset;

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
