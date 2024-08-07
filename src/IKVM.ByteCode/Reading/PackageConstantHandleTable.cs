using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct PackageConstantHandleTable : IReadOnlyList<PackageConstantHandle>
    {

        public struct Enumerator : IEnumerator<PackageConstantHandle>
        {

            readonly PackageConstantHandle[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(PackageConstantHandle[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly PackageConstantHandle Current => _items[_index];

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

        readonly PackageConstantHandle[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal PackageConstantHandleTable(PackageConstantHandle[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the package handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly PackageConstantHandle this[int index] => GetItem(index);

        /// <summary>
        /// Gets the package handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly PackageConstantHandle GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of package handles.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the package handles.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<PackageConstantHandle> IEnumerable<PackageConstantHandle>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
