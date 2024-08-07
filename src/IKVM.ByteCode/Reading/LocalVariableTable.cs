﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct LocalVariableTable : IReadOnlyList<LocalVariable>
    {

        public struct Enumerator : IEnumerator<LocalVariable>
        {

            readonly LocalVariable[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(LocalVariable[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly LocalVariable Current => _items[_index];

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

        readonly LocalVariable[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal LocalVariableTable(LocalVariable[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the local variable at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly LocalVariable this[int index] => GetItem(index);

        /// <summary>
        /// Gets the local variable at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly LocalVariable GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of local variables.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the local variables.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<LocalVariable> IEnumerable<LocalVariable>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}