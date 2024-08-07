using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct AnnotationTable : IReadOnlyList<Annotation>
    {

        public struct Enumerator : IEnumerator<Annotation>
        {

            readonly Annotation[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(Annotation[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly Annotation Current => _items[_index];

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

        readonly Annotation[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal AnnotationTable(Annotation[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the annotation at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly Annotation this[int index] => GetItem(index);

        /// <summary>
        /// Gets the annotation at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly Annotation GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of annotations.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the annotations.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<Annotation> IEnumerable<Annotation>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
