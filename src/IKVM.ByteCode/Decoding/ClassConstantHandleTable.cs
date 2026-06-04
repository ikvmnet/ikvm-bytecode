using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a table of class constant handles decoded from a class file.
    /// </summary>
    public readonly struct ClassConstantHandleTable : IReadOnlyList<ClassConstantHandle>
    {

        /// <summary>
        /// Enumerates the class constant handles in the table.
        /// </summary>
        public struct Enumerator : IEnumerator<ClassConstantHandle>
        {

            readonly ClassConstantHandle[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items">The backing array of items.</param>
            internal Enumerator(ClassConstantHandle[] items)
            {
                _items = items ?? [];
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ClassConstantHandle Current => ref _items[_index];

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
            readonly ClassConstantHandle IEnumerator<ClassConstantHandle>.Current => Current;

        }

        /// <summary>
        /// Gets an empty table.
        /// </summary>
        public static readonly ClassConstantHandleTable Empty = new([]);

        readonly ClassConstantHandle[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items">The backing array of items.</param>
        internal ClassConstantHandleTable(ClassConstantHandle[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the constant handle at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public readonly ref readonly ClassConstantHandle this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the constant handle at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        readonly ref readonly ClassConstantHandle GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            return ref _items[index];
        }

        /// <summary>
        /// Gets the number of constant handles.
        /// </summary>
        public readonly int Count => _items?.Length ?? 0;

        /// <summary>
        /// Gets an enumerator over the constant handles.
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
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ClassConstantTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            foreach (var i in this)
                encoder.Class(constantPool.Get(constantView.Get(i)));
        }

        /// <inheritdoc />
        readonly IEnumerator<ClassConstantHandle> IEnumerable<ClassConstantHandle>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ClassConstantHandle IReadOnlyList<ClassConstantHandle>.this[int index] => this[index];

    }



}
