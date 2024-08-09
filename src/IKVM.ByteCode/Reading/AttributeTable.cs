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
            public readonly Attribute Current => _attributes[_index];

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
        public readonly Attribute this[int index] => GetAttribute(index);

        /// <summary>
        /// Gets the attribute at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly Attribute GetAttribute(int index) => _items[index];

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
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="builder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, AttributeTableBuilder builder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            foreach (var i in this)
                i.EncodeTo(view, pool, builder);
        }

        /// <inheritdoc />
        readonly IEnumerator<Attribute> IEnumerable<Attribute>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
