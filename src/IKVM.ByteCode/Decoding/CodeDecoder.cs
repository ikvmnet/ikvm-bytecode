using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public ref struct CodeDecoder
    {

        public ref struct Enumerator
        {

            CodeDecoder _decoder;
            Instruction _current;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="decoder"></param>
            internal Enumerator(CodeDecoder decoder)
            {
                _decoder = decoder;
            }

            /// <inheritdoc />
            public readonly Instruction Current => _current;

            /// <inheritdoc />
            public bool MoveNext()
            {
                _current = _decoder.ReadNext();
                return _current.IsNotNil;
            }

            /// <inheritdoc />
            public readonly void Reset()
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc />
            public readonly void Dispose()
            {

            }

        }

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
        public bool TryReadNext(out Instruction instruction)
        {
            return Instruction.TryRead(ref _data, out instruction);
        }

        /// <summary>
        /// Attempts to read the next instruction in the code. If there are no further instructions, a nil instance is returned.
        /// </summary>
        /// <returns></returns>
        public Instruction ReadNext()
        {
            return Instruction.Read(ref _data);
        }

        /// <summary>
        /// Gets an enumerator over the frames.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(this);

    }

}
