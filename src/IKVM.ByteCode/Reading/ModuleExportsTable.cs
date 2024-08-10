using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ModuleExportsTable : IReadOnlyList<ModuleExportInfo>
    {

        public struct Enumerator : IEnumerator<ModuleExportInfo>
        {

            readonly ModuleExportInfo[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ModuleExportInfo[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ModuleExportInfo Current => ref _items[_index];

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
            readonly ModuleExportInfo IEnumerator<ModuleExportInfo>.Current => Current;

        }

        public static readonly ModuleExportsTable Empty = new([]);

        readonly ModuleExportInfo[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ModuleExportsTable(ModuleExportInfo[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public readonly ref readonly ModuleExportInfo this[int index] => ref GetItem(index);

        readonly ref readonly ModuleExportInfo GetItem(int index) => ref _items[index];

        public readonly int Count => _items.Length;

        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref ModuleExportsTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in this)
                i.EncodeTo(map, ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<ModuleExportInfo> IEnumerable<ModuleExportInfo>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ModuleExportInfo IReadOnlyList<ModuleExportInfo>.this[int index] => this[index];

    }



}
