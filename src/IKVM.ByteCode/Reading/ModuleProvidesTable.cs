using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ModuleProvidesTable : IReadOnlyList<ModuleProvideInfo>
    {

        public struct Enumerator : IEnumerator<ModuleProvideInfo>
        {

            readonly ModuleProvideInfo[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ModuleProvideInfo[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ModuleProvideInfo Current => ref _items[_index];

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
            readonly ModuleProvideInfo IEnumerator<ModuleProvideInfo>.Current => Current;

        }

        readonly ModuleProvideInfo[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ModuleProvidesTable(ModuleProvideInfo[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public readonly ref readonly ModuleProvideInfo this[int index] => ref GetItem(index);

        readonly ref readonly ModuleProvideInfo GetItem(int index) => ref _items[index];

        public readonly int Count => _items.Length;

        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref ModuleProvidesTableEncoder encoder)
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
        readonly IEnumerator<ModuleProvideInfo> IEnumerable<ModuleProvideInfo>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ModuleProvideInfo IReadOnlyList<ModuleProvideInfo>.this[int index] => this[index];

    }



}
