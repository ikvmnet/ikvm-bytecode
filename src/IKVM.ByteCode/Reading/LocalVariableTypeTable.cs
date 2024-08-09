using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

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

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref LocalVariableTypeTableEncoder encoder)
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
        readonly IEnumerator<LocalVariableType> IEnumerable<LocalVariableType>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
