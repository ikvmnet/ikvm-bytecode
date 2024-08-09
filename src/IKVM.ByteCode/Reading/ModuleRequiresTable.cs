using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

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
            public readonly ref readonly ModuleRequireInfo Current => ref _items[_index];

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
            readonly ModuleRequireInfo IEnumerator<ModuleRequireInfo>.Current => Current;

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

        /// <summary>
        /// Gets a reference to the table item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly ModuleRequireInfo this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the table item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly ModuleRequireInfo GetItem(int index) => ref _items[index];

        /// <summary>
        /// Gets the number of items in the table.
        /// </summary>
        public readonly int Count => _items.Length;

        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref ModuleRequiresTableEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            foreach (var i in this)
                i.EncodeTo(view, pool, ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<ModuleRequireInfo> IEnumerable<ModuleRequireInfo>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ModuleRequireInfo IReadOnlyList<ModuleRequireInfo>.this[int index] => this[index];

    }



}
