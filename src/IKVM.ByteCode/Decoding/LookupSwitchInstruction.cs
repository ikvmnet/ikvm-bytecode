using System;
using System.Buffers;
using System.Runtime.CompilerServices;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a decoded <c>lookupswitch</c> instruction.
    /// </summary>
    /// <param name="DefaultTarget">The signed branch offset for the default case.</param>
    /// <param name="Cases">The table of key-target pairs.</param>
    public readonly record struct LookupSwitchInstruction(int DefaultTarget, LookupSwitchCaseTable Cases)
    {

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LookupSwitchInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LookupSwitchInstruction(Instruction value) => value.AsLookupSwitch();

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="offset">The bytecode offset.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        internal static bool TryMeasure(ref SequenceReader<byte> reader, int offset, ref int size)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LookupSwitch)
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

            // npairs is always 4 bytes
            if (LookupSwitchCaseTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="data">The raw data buffer.</param>
        /// <param name="instruction">The decoded instruction.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ReadOnlySequence<byte> data, int offset, out LookupSwitchInstruction instruction)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, offset, out instruction);
        }

        /// <summary>
        /// Attempts to measure the size of the instruction.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="instruction">The decoded instruction.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        internal static bool TryRead(ref SequenceReader<byte> reader, int offset, out LookupSwitchInstruction instruction)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LookupSwitch)
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

        /// <summary>
        /// Copies this instruction to the builder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="builder">The encoder builder.</param>
        /// <param name="offset">The bytecode offset.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, CodeBuilder builder, int offset)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            builder.OpCode(OpCode.LookupSwitch);
            builder.Align(4);
            builder.WriteJ4(DefaultTarget + offset);
            builder.WriteInt32(Cases.Count);

            foreach (var c in Cases)
            {
                builder.WriteInt32(c.Key);
                builder.WriteJ4(c.Target + offset);
            }
        }

    }

}