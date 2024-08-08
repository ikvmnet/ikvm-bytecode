using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct LineNumberTable : IReadOnlyList<LineNumberInfo>
    {

        public struct Enumerator : IEnumerator<LineNumberInfo>
        {

            readonly LineNumberInfo[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(LineNumberInfo[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly LineNumberInfo Current => _items[_index];

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

        readonly LineNumberInfo[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal LineNumberTable(LineNumberInfo[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the line number at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly LineNumberInfo this[int index] => GetItem(index);

        /// <summary>
        /// Gets the line number at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly LineNumberInfo GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of line numbers.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the line numbers.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<LineNumberInfo> IEnumerable<LineNumberInfo>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
