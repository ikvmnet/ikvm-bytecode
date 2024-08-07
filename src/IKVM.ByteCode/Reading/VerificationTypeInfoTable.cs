using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct VerificationTypeInfoTable : IReadOnlyList<VerificationTypeInfo>
    {

        public struct Enumerator : IEnumerator<VerificationTypeInfo>
        {

            readonly VerificationTypeInfo[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(VerificationTypeInfo[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly VerificationTypeInfo Current => _items[_index];

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

        readonly VerificationTypeInfo[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal VerificationTypeInfoTable(VerificationTypeInfo[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the type info at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public VerificationTypeInfo this[int index] => GetItem(index);

        /// <summary>
        /// Gets the type info at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        VerificationTypeInfo GetItem(int index) => _items[index];

        /// <summary>
        /// Gets the number of type infos.
        /// </summary>
        public int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the type infos.
        /// </summary>
        public Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        IEnumerator<VerificationTypeInfo> IEnumerable<VerificationTypeInfo>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }



}
