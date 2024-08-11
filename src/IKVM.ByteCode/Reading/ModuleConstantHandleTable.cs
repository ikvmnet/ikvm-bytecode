using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ModuleConstantHandleTable : IReadOnlyList<ModuleConstantHandle>
    {

        public struct Enumerator : IEnumerator<ModuleConstantHandle>
        {

            readonly ModuleConstantHandle[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ModuleConstantHandle[] items)
            {
                _items = items ?? [];
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ModuleConstantHandle Current => ref _items[_index];

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

            /// <inheritdoc />
            readonly ModuleConstantHandle IEnumerator<ModuleConstantHandle>.Current => Current;

        }

        public static readonly ModuleConstantHandleTable Empty = new([]);

        readonly ModuleConstantHandle[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ModuleConstantHandleTable(ModuleConstantHandle[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the module handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly ModuleConstantHandle this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets a reference to the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly ModuleConstantHandle GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            return ref _items[index];
        }

        /// <summary>
        /// Gets the number of module handles.
        /// </summary>
        public readonly int Count => _items?.Length ?? 0;

        /// <summary>
        /// Gets an enumerator over the module handles.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<ModuleConstantHandle> IEnumerable<ModuleConstantHandle>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ModuleConstantHandle IReadOnlyList<ModuleConstantHandle>.this[int index] => this[index];

    }



}
