using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Provides a decoder that reads instructions from a code sequence.
    /// </summary>
    public ref struct CodeDecoder
    {

        public ref struct Enumerator
        {

            CodeDecoder _decoder;
            Instruction _current;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="decoder">The code decoder to enumerate instructions from.</param>
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

        SequenceReader<byte> _reader;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="data">The raw data buffer.</param>
        public CodeDecoder(ReadOnlySequence<byte> data)
        {
            _reader = new SequenceReader<byte>(data);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="span">The bytecode span to read from.</param>
        public CodeDecoder(ReadOnlyMemory<byte> span) :
            this(new ReadOnlySequence<byte>(span))
        {

        }

        /// <summary>
        /// Attempts to read the next instruction in the code.
        /// </summary>
        /// <param name="instruction">The decoded instruction.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public bool TryReadNext(out Instruction instruction)
        {
            return Instruction.TryRead(ref _reader, out instruction);
        }

        /// <summary>
        /// Attempts to read the next instruction in the code. If there are no further instructions, a nil instance is returned.
        /// </summary>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public Instruction ReadNext()
        {
            return Instruction.Read(ref _reader);
        }

        /// <summary>
        /// Copies this code sequence to the specified code builder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="builder">The encoder builder.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, CodeBuilder builder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            var offset = builder.Offset;
            foreach (var instruction in this)
                instruction.CopyTo(constantView, constantPool, builder, offset);
        }

        /// <summary>
        /// Gets the count of bytes in the reader.
        /// </summary>
        public readonly long Length => _reader.Length;

        /// <summary>
        /// Gets the current position in the reader.
        /// </summary>
        public readonly SequencePosition Position => _reader.Position;

        /// <summary>
        /// Gets the amount of data that has been consumed by this reader.
        /// </summary>
        public readonly long Consumed => _reader.Consumed;

        /// <summary>
        /// Gets the number of remaining bytes in the reader.
        /// </summary>
        public readonly long Remaining => _reader.Remaining;

        /// <summary>
        /// Gets an enumerator over the frames.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(this);

    }

}
