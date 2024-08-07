using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ModuleProvidesTable : IReadOnlyList<ModuleProvides>
    {

        public struct Enumerator : IEnumerator<ModuleProvides>
        {

            readonly ModuleProvides[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ModuleProvides[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ModuleProvides Current => _items[_index];

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

        readonly ModuleProvides[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ModuleProvidesTable(ModuleProvides[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public readonly ModuleProvides this[int index] => GetItem(index);

        readonly ModuleProvides GetItem(int index) => _items[index];

        public readonly int Count => _items.Length;

        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<ModuleProvides> IEnumerable<ModuleProvides>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
