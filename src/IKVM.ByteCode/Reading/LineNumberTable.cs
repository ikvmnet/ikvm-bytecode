using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct LineNumberTable : IReadOnlyList<LineNumber>
    {

        public struct Enumerator : IEnumerator<LineNumber>
        {

            readonly LineNumber[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(LineNumber[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly LineNumber Current => _items[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _items.Length;
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

        }

        readonly LineNumber[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal LineNumberTable(LineNumber[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the line number at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly LineNumber this[int index] => GetItem(index);

        /// <summary>
        /// Gets the line number at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly LineNumber GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of line numbers.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the line numbers.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<LineNumber> IEnumerable<LineNumber>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
