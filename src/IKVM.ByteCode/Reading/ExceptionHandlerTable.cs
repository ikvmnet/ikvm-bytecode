﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ExceptionHandlerTable : IReadOnlyList<ExceptionHandler>
    {

        public struct Enumerator : IEnumerator<ExceptionHandler>
        {

            readonly ExceptionHandler[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ExceptionHandler[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ExceptionHandler Current => _items[_index];

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

        readonly ExceptionHandler[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ExceptionHandlerTable(ExceptionHandler[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the exception handler at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ExceptionHandler this[int index] => GetItem(index);

        /// <summary>
        /// Gets the exception handler at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ExceptionHandler GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of exception handlers.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the exception handlers.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        IEnumerator<ExceptionHandler> IEnumerable<ExceptionHandler>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
