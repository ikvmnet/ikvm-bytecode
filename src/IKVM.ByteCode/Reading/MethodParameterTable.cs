using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct MethodParameterTable : IReadOnlyList<MethodParameter>
    {

        public struct Enumerator : IEnumerator<MethodParameter>
        {

            readonly MethodParameter[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(MethodParameter[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly MethodParameter Current => _items[_index];

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

        readonly MethodParameter[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal MethodParameterTable(MethodParameter[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the method parameter at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly MethodParameter this[int index] => GetItem(index);

        /// <summary>
        /// Gets the method parameter at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly MethodParameter GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of method parameters.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the method parameters.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<MethodParameter> IEnumerable<MethodParameter>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
