using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct TypeAnnotationTable : IReadOnlyList<TypeAnnotation>
    {

        public struct Enumerator : IEnumerator<TypeAnnotation>
        {

            readonly TypeAnnotation[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(TypeAnnotation[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly TypeAnnotation Current => _items[_index];

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

        readonly TypeAnnotation[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal TypeAnnotationTable(TypeAnnotation[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the type annotation at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly TypeAnnotation this[int index] => GetItem(index);

        /// <summary>
        /// Gets the type annotation at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly TypeAnnotation GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of type annotations.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the type annotations.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<TypeAnnotation> IEnumerable<TypeAnnotation>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
