﻿using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Encoding;

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

        SequenceReader<byte> _reader;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="data"></param>
        public CodeDecoder(ReadOnlySequence<byte> data)
        {
            _reader = new SequenceReader<byte>(data);
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
            return Instruction.TryRead(ref _reader, out instruction);
        }

        /// <summary>
        /// Attempts to read the next instruction in the code. If there are no further instructions, a nil instance is returned.
        /// </summary>
        /// <returns></returns>
        public Instruction ReadNext()
        {
            return Instruction.Read(ref _reader);
        }

        /// <summary>
        /// Copies this code sequence to the specified builder.
        /// </summary>
        /// <typeparam name="TConstantMap"></typeparam>
        /// <param name="map"></param>
        /// <param name="builder"></param>
        public void CopyTo<TConstantMap>(TConstantMap map, CodeBuilder builder)
            where TConstantMap : IConstantMap
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            foreach (var instruction in this)
                CopyInstructionTo(map, instruction, builder);
        }

        /// <summary>
        /// Copies the specified instruction to the builder.
        /// </summary>
        /// <typeparam name="TConstantMap"></typeparam>
        /// <param name="map"></param>
        /// <param name="instruction"></param>
        /// <param name="builder"></param>
        void CopyInstructionTo<TConstantMap>(TConstantMap map, Instruction instruction, CodeBuilder builder)
            where TConstantMap : IConstantMap
        {
            instruction.CopyTo(map, builder);
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
