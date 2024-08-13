using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public ref struct CodeDecoder
    {

        SequenceReader<byte> _data;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="data"></param>
        public CodeDecoder(ReadOnlySequence<byte> data)
        {
            _data = new SequenceReader<byte>(data);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="span"></param>
        public CodeDecoder(ReadOnlyMemory<byte> span) :
            this(new ReadOnlySequence<byte>(span))
        {

        }

        /// <summary>
        /// Attempts to read the next instruction in the code.
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public bool TryRead(out Instruction instruction)
        {
            return Instruction.TryRead(ref _data, out instruction);
        }

    }

}
