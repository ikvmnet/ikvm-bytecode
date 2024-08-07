using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ClassConstantHandleTable : IReadOnlyList<ClassConstantHandle>
    {

        public struct Enumerator : IEnumerator<ClassConstantHandle>
        {

            readonly ClassConstantHandle[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ClassConstantHandle[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ClassConstantHandle Current => _items[_index];

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

        readonly ClassConstantHandle[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ClassConstantHandleTable(ClassConstantHandle[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the constant handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ClassConstantHandle this[int index] => GetItem(index);

        /// <summary>
        /// Gets the constant handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ClassConstantHandle GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of constant handles.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the constant handles.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<ClassConstantHandle> IEnumerable<ClassConstantHandle>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
