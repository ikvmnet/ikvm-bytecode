using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct BootstrapMethodTable : IReadOnlyList<BootstrapMethod>
    {

        public struct Enumerator : IEnumerator<BootstrapMethod>
        {

            readonly BootstrapMethod[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(BootstrapMethod[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly BootstrapMethod Current => ref _items[_index];

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
            readonly BootstrapMethod IEnumerator<BootstrapMethod>.Current => Current;

        }

        readonly BootstrapMethod[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal BootstrapMethodTable(BootstrapMethod[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the constant handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly BootstrapMethod this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the constant handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly BootstrapMethod GetItem(int index) => ref _items[index];

        /// <summary>
        /// Gets the number of constant handles.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the constant handles.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref BootstrapMethodTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in this)
                i.EncodeTo(map, ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<BootstrapMethod> IEnumerable<BootstrapMethod>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly BootstrapMethod IReadOnlyList<BootstrapMethod>.this[int index] => this[index];

    }



}
