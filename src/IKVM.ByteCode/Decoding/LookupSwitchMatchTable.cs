using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly struct LookupSwitchMatchTable : IReadOnlyList<LookupSwitchMatch>
    {

        public struct Enumerator : IEnumerator<LookupSwitchMatch>
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
            public readonly LookupSwitchMatch Current
            {
                get
                {
                    var reader = new SequenceReader<byte>(_data.Slice(_index * 8, 8));
                    if (LookupSwitchMatch.TryRead(ref reader, out var match) == false)
                        throw new InvalidCodeException("Unexpected end of memory while reading a LookupSwitchMatch.");

                    return match;
                }
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < (_data.Length / 8);
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
            readonly LookupSwitchMatch IEnumerator<LookupSwitchMatch>.Current => Current;

        }

        /// <summary>
        /// Attepmpts to measure the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            size += 4;
            if (reader.TryReadBigEndian(out int npairs) == false)
                return false;

            var pairsSize = npairs * 8;
            size += pairsSize;
            if (reader.TryAdvance(pairsSize) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="matches"></param>
        /// <returns></returns>
        internal static bool TryRead(ref SequenceReader<byte> reader, out LookupSwitchMatchTable matches)
        {
            matches = default;

            if (reader.TryReadBigEndian(out int npairs) == false)
                return false;

            var pairsSize = npairs * 8;
            if (reader.TryReadExact(pairsSize, out var items) == false)
                return false;

            matches = new LookupSwitchMatchTable(items);
            return true;
        }

        public static readonly LookupSwitchMatchTable Empty = new(ReadOnlySequence<byte>.Empty);

        readonly ReadOnlySequence<byte> _data;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="data"></param>
        internal LookupSwitchMatchTable(ReadOnlySequence<byte> data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets a reference to the match at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly LookupSwitchMatch this[int index] => GetItem(index);

        /// <summary>
        /// Gets the match at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly LookupSwitchMatch GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var reader = new SequenceReader<byte>(_data.Slice(index * 8, 64));
            if (LookupSwitchMatch.TryRead(ref reader, out var match) == false)
                throw new InvalidCodeException("Unexpected end of memory while reading a LookupSwitchMatch.");

            return match;
        }

        /// <summary>
        /// Gets the number of matches.
        /// </summary>
        public readonly int Count => (int)_data.Length / 8;

        /// <summary>
        /// Gets an enumerator over the matches.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_data);

        /// <inheritdoc />
        readonly IEnumerator<LookupSwitchMatch> IEnumerable<LookupSwitchMatch>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly LookupSwitchMatch IReadOnlyList<LookupSwitchMatch>.this[int index] => this[index];

    }

}