using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ModuleRequiresTable : IReadOnlyList<ModuleRequireInfo>
    {

        public struct Enumerator : IEnumerator<ModuleRequireInfo>
        {

            readonly ModuleRequireInfo[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ModuleRequireInfo[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ModuleRequireInfo Current => _items[_index];

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

        readonly ModuleRequireInfo[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ModuleRequiresTable(ModuleRequireInfo[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public readonly ModuleRequireInfo this[int index] => GetItem(index);

        readonly ModuleRequireInfo GetItem(int index) => _items[index];

        public readonly int Count => _items.Length;

        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<ModuleRequireInfo> IEnumerable<ModuleRequireInfo>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
