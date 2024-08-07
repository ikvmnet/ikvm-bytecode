using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ModuleRequiresTable : IReadOnlyList<ModuleRequires>
    {

        public struct Enumerator : IEnumerator<ModuleRequires>
        {

            readonly ModuleRequires[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ModuleRequires[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ModuleRequires Current => _items[_index];

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

        readonly ModuleRequires[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ModuleRequiresTable(ModuleRequires[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public readonly ModuleRequires this[int index] => GetItem(index);

        readonly ModuleRequires GetItem(int index) => _items[index];

        public readonly int Count => _items.Length;

        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<ModuleRequires> IEnumerable<ModuleRequires>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
