using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct RecordComponentTable : IReadOnlyList<RecordComponent>
    {

        public struct Enumerator : IEnumerator<RecordComponent>
        {

            readonly RecordComponent[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(RecordComponent[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly RecordComponent Current => ref _items[_index];

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
            readonly RecordComponent IEnumerator<RecordComponent>.Current => Current;

        }

        readonly RecordComponent[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal RecordComponentTable(RecordComponent[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the record component at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly RecordComponent this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the record component at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly RecordComponent GetItem(int index) => ref _items[index];

        /// <summary>
        /// Gets the number of record components.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the record components.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref RecordComponentTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in this)
                i.EncodeTo(map, ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<RecordComponent> IEnumerable<RecordComponent>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly RecordComponent IReadOnlyList<RecordComponent>.this[int index] => this[index];

    }



}
