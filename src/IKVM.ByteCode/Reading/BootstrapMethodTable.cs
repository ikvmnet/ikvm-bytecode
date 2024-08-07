using System;
using System.Collections;
using System.Collections.Generic;

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
            public readonly BootstrapMethod Current => _items[_index];

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
        public BootstrapMethod this[int index] => GetItem(index);

        /// <summary>
        /// Gets the constant handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        BootstrapMethod GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of constant handles.
        /// </summary>
        public int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the constant handles.
        /// </summary>
        public Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        IEnumerator<BootstrapMethod> IEnumerable<BootstrapMethod>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
