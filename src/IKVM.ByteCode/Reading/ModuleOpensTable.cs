﻿using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ModuleOpensTable : IReadOnlyList<ModuleOpenInfo>
    {

        public struct Enumerator : IEnumerator<ModuleOpenInfo>
        {

            readonly ModuleOpenInfo[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ModuleOpenInfo[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ModuleOpenInfo Current => ref _items[_index];

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
            readonly ModuleOpenInfo IEnumerator<ModuleOpenInfo>.Current => Current;

        }

        public static readonly ModuleOpensTable Empty = new([]);

        readonly ModuleOpenInfo[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ModuleOpensTable(ModuleOpenInfo[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public readonly ref readonly ModuleOpenInfo this[int index] => ref GetItem(index);

        readonly ref readonly ModuleOpenInfo GetItem(int index) => ref _items[index];

        public readonly int Count => _items.Length;

        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref ModuleOpensTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in this)
                i.EncodeTo(map, ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<ModuleOpenInfo> IEnumerable<ModuleOpenInfo>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ModuleOpenInfo IReadOnlyList<ModuleOpenInfo>.this[int index] => this[index];

    }



}
