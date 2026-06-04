using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the local variable table decoded from the <c>LocalVariableTable</c> attribute.
    /// </summary>
    public readonly struct LocalVariableTable : IReadOnlyList<LocalVariable>
    {

        /// <summary>
        /// Enumerates the local variable entries in the table.
        /// </summary>
        public struct Enumerator : IEnumerator<LocalVariable>
        {

            readonly LocalVariable[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items">The backing array of items.</param>
            internal Enumerator(LocalVariable[] items)
            {
                _items = items ?? [];
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly LocalVariable Current => ref _items[_index];

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
            readonly LocalVariable IEnumerator<LocalVariable>.Current => Current;

        }

        /// <summary>
        /// Gets an empty table.
        /// </summary>
        public static readonly LocalVariableTable Empty = new([]);

        readonly LocalVariable[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items">The backing array of items.</param>
        internal LocalVariableTable(LocalVariable[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the local variable at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public readonly ref readonly LocalVariable this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the local variable at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        readonly ref readonly LocalVariable GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            return ref _items[index];
        }

        /// <summary>
        /// Gets the number of local variables.
        /// </summary>
        public readonly int Count => _items?.Length ?? 0;

        /// <summary>
        /// Gets an enumerator over the local variables.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Copies this table to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref LocalVariableTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            foreach (var i in this)
                i.CopyTo(constantView, constantPool, ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<LocalVariable> IEnumerable<LocalVariable>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly LocalVariable IReadOnlyList<LocalVariable>.this[int index] => this[index];

    }



}
