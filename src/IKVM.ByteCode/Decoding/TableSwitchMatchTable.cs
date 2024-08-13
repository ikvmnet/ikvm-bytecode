using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly struct TableSwitchMatchTable : IReadOnlyList<int>
    {

        public struct Enumerator : IEnumerator<int>
        {

            readonly ReadOnlySequence<byte> _data;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="data"></param>
            internal Enumerator(ReadOnlySequence<byte> data)
            {
                _data = data;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly int Current
            {
                get
                {
                    var reader = new SequenceReader<byte>(_data);
                    if (reader.TryAdvance(_index * 4) == false)
                        throw new InvalidCodeException("Unexpected end of memory while reading a table match item.");
                    if (reader.TryReadBigEndian(out int target) == false)
                        throw new InvalidCodeException("Unexpected end of memory while reading a table match item.");

                    return target;
                }
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < (_data.Length / 4);
            }

            /// <inheritdoc />
            public void Reset()
            {
                _index = -1;
            }

            /// <inheritdoc />
            public readonly void Dispose()
            {

            }

            /// <inheritdoc />
            readonly object IEnumerator.Current => Current;

            /// <inheritdoc />
            readonly int IEnumerator<int>.Current => Current;

        }

        /// <summary>
        /// Attepmpts to measure the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static bool TryMeasure(ref SequenceReader<byte> reader, int count, ref int size)
        {
            // each item between low/high inclusive is a 4 byte label
            var l = count * 4;
            size += l;
            if (reader.TryAdvance(l) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="matches"></param>
        /// <returns></returns>
        internal static bool TryRead(ref SequenceReader<byte> reader, int count, out TableSwitchMatchTable matches)
        {
            matches = default;

            // each item between low/high inclusive is a 4 byte label
            var l = count * 4;
            if (reader.TryReadExact(l, out var data) == false)
                return false;

            matches = new TableSwitchMatchTable(data);
            return true;
        }

        public static readonly TableSwitchMatchTable Empty = new(ReadOnlySequence<byte>.Empty);

        readonly ReadOnlySequence<byte> _data;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="data"></param>
        internal TableSwitchMatchTable(ReadOnlySequence<byte> data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets a reference to the match at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly int this[int index] => GetItem(index);

        /// <summary>
        /// Gets the match at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly int GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var reader = new SequenceReader<byte>(_data);
            if (reader.TryAdvance(index * 4) == false)
                throw new InvalidCodeException("Unexpected end of memory while reading a table match item.");
            if (reader.TryReadBigEndian(out int target) == false)
                throw new InvalidCodeException("Unexpected end of memory while reading a table match item.");

            return target;
        }

        /// <summary>
        /// Gets the number of matches.
        /// </summary>
        public readonly int Count => (int)_data.Length / 4;

        /// <summary>
        /// Gets an enumerator over the matches.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_data);

        /// <inheritdoc />
        readonly IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly int IReadOnlyList<int>.this[int index] => this[index];

    }

}
