﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct TypePath : IReadOnlyList<TypePathItem>
    {

        public struct Enumerator : IEnumerator<TypePathItem>
        {

            readonly TypePathItem[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(TypePathItem[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly TypePathItem Current => _items[_index];

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

        public static bool TryRead(ref ClassFormatReader reader, out TypePath typePath)
        {
            typePath = default;

            if (reader.TryReadU1(out byte length) == false)
                return false;

            var path = length == 0 ? [] : new TypePathItem[length];
            for (int i = 0; i < length; i++)
            {
                if (TypePathItem.TryRead(ref reader, out var item) == false)
                    return false;

                path[i] = item;
            }

            typePath = new TypePath(path);
            return true;
        }

        readonly TypePathItem[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal TypePath(TypePathItem[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly TypePathItem this[int index] => GetItem(index);

        /// <summary>
        /// Gets the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly TypePathItem GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of items.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the items.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<TypePathItem> IEnumerable<TypePathItem>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}