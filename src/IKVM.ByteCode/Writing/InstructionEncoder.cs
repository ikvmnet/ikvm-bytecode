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

        readonly BlobBuilder _code;
        readonly ControlFlowBuilder? _control;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="control"></param>
        public InstructionEncoder(BlobBuilder code, ControlFlowBuilder? control = null)
        {
            _code = code ?? throw new ArgumentNullException(nameof(code));
            _control = control;
        }

        public int Offset => _code.Count;

        /// <summary>
        /// Encodes the specified op-code.
        /// </summary>
        /// <param name="code"></param>
        public void OpCode(OpCode code)
        {
            var w = new ClassFormatWriter(_code.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1((byte)code);
        }

        /// <summary>
        /// Encodes a 8 bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        public void UInt8(byte value)
        {
            var w = new ClassFormatWriter(_code.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(value);
        }

        /// <summary>
        /// Encodes a 16-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        public void UInt16(ushort value)
        {
            var w = new ClassFormatWriter(_code.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(value);
        }

        /// <summary>
        /// Encodes a 32-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        public void UInt32(uint value)
        {
            var w = new ClassFormatWriter(_code.ReserveBytes(ClassFormatWriter.U4).GetBytes());
            w.TryWriteU4(value);
        }

    }

}
