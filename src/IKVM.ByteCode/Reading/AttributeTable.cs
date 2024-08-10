using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    /// <summary>
    /// Table of attribute data.
    /// </summary>
    public readonly struct AttributeTable : IReadOnlyList<Attribute>
    {

        public struct Enumerator : IEnumerator<Attribute>
        {

            readonly Attribute[] _attributes;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="attributes"></param>
            internal Enumerator(Attribute[] attributes)
            {
                _attributes = attributes;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly Attribute Current => ref _attributes[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _attributes.Length;
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
            readonly Attribute IEnumerator<Attribute>.Current => Current;

        }

        readonly Attribute[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal AttributeTable(Attribute[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the attribute at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly Attribute this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the attribute at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly Attribute GetItem(int index) => ref _items[index];

        /// <summary>
        /// Gets the number of fields.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the fields.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref AttributeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in this)
                i.EncodeTo(map, ref encoder);
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref AttributeTableEncoder encoder)
        {
            foreach (var i in this)
                i.WriteTo(ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<Attribute> IEnumerable<Attribute>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly Attribute IReadOnlyList<Attribute>.this[int index] => this[index];

    }

}
