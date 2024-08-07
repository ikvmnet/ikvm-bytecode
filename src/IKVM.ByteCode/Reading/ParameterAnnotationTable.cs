using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ParameterAnnotationTable : IReadOnlyList<ParameterAnnotation>
    {

        public struct Enumerator : IEnumerator<ParameterAnnotation>
        {

            readonly ParameterAnnotation[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ParameterAnnotation[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ParameterAnnotation Current => _items[_index];

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

        readonly ParameterAnnotation[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ParameterAnnotationTable(ParameterAnnotation[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the parameter at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ParameterAnnotation this[int index] => GetItem(index);

        /// <summary>
        /// Gets the parameter at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ParameterAnnotation GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of parameters.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the parameters.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<ParameterAnnotation> IEnumerable<ParameterAnnotation>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
