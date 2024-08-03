using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes instructions.
    /// </summary>
    readonly struct InstructionEncoder
    {

        readonly BlobBuilder _builder;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="control"></param>
        public InstructionEncoder(BlobBuilder code)
        {
            _builder = code ?? throw new ArgumentNullException(nameof(code));
        }

        /// <summary>
        /// Gets the offset of the next instruction inserted.
        /// </summary>
        public int Offset => _builder.Count;

        /// <summary>
        /// Encodes the specified op-code.
        /// </summary>
        /// <param name="code"></param>
        public void OpCode(OpCode code)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1((byte)code);
        }

        /// <summary>
        /// Aligns the current position of the writer on <paramref name="alignment"/> boundary.
        /// </summary>
        /// <param name="alignment"></param>
        public void Align(int alignment)
        {
            _builder.Align(alignment);
        }

        /// <summary>
        /// Encodes a 8 bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        public void UInt8(byte value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(value);
        }

        /// <summary>
        /// Encodes a 16-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        public void UInt16(ushort value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(value);
        }

        /// <summary>
        /// Encodes a 32-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        public void UInt32(uint value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U4).GetBytes());
            w.TryWriteU4(value);
        }

    }

}
