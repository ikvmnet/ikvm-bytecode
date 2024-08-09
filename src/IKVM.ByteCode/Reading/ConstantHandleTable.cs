﻿using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ConstantHandleTable : IReadOnlyList<ConstantHandle>
    {

        public struct Enumerator : IEnumerator<ConstantHandle>
        {

            readonly ConstantHandle[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ConstantHandle[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ConstantHandle Current => ref _items[_index];

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
            readonly ConstantHandle IEnumerator<ConstantHandle>.Current => Current;

        }

        readonly ConstantHandle[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ConstantHandleTable(ConstantHandle[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the constant handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly ConstantHandle this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the constant handle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly ConstantHandle GetItem(int index) => ref _items[index];

        /// <summary>
        /// Gets the number of constant handles.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the constant handles.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref ConstantTableEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            foreach (var i in this)
                encoder.Constant(pool.Import(view, i));
        }

        /// <inheritdoc />
        readonly IEnumerator<ConstantHandle> IEnumerable<ConstantHandle>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ConstantHandle IReadOnlyList<ConstantHandle>.this[int index] => this[index];

    }



}
