using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

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
            public readonly ref readonly LineNumberInfo Current => ref _items[_index];

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

            /// <inheritdoc />
            readonly LineNumberInfo IEnumerator<LineNumberInfo>.Current => Current;

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
        public readonly ref readonly LineNumberInfo this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the line number at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly LineNumberInfo GetItem(int index) => ref _items[index];

        /// <summary>
        /// Gets the number of line numbers.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the line numbers.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref LineNumberTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in this)
                i.EncodeTo(map, ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<LineNumberInfo> IEnumerable<LineNumberInfo>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly LineNumberInfo IReadOnlyList<LineNumberInfo>.this[int index] => this[index];

    }



}
