using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ModuleExportsTable : IReadOnlyList<ModuleExports>
    {

        public struct Enumerator : IEnumerator<ModuleExports>
        {

            readonly ModuleExports[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ModuleExports[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ModuleExports Current => _items[_index];

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

        readonly ModuleExports[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ModuleExportsTable(ModuleExports[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public readonly ModuleExports this[int index] => GetItem(index);

        readonly ModuleExports GetItem(int index) => _items[index];

        public readonly int Count => _items.Length;

        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<ModuleExports> IEnumerable<ModuleExports>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
