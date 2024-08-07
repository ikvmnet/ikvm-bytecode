﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct LocalVariableTypeTable : IReadOnlyList<LocalVariableType>
    {

        public struct Enumerator : IEnumerator<LocalVariableType>
        {

            readonly LocalVariableType[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(LocalVariableType[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly LocalVariableType Current => _items[_index];

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

        readonly LocalVariableType[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal LocalVariableTypeTable(LocalVariableType[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the local variable type at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly LocalVariableType this[int index] => GetItem(index);

        /// <summary>
        /// Gets the local variable type at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly LocalVariableType GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of local variable types.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the local variable types.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<LocalVariableType> IEnumerable<LocalVariableType>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}