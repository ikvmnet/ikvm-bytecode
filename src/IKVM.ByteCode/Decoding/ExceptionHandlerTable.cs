using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the exception table of a <c>Code</c> attribute decoded from a class file.
    /// </summary>
    public readonly struct ExceptionHandlerTable : IReadOnlyList<ExceptionHandler>
    {

        /// <summary>
        /// Enumerates the exception handlers in the table.
        /// </summary>
        public struct Enumerator : IEnumerator<ExceptionHandler>
        {

            readonly ExceptionHandler[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items">The backing array of items.</param>
            internal Enumerator(ExceptionHandler[] items)
            {
                _items = items ?? [];
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ExceptionHandler Current => ref _items[_index];

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
            readonly ExceptionHandler IEnumerator<ExceptionHandler>.Current => Current;

        }

        /// <summary>
        /// Attempts to measure the exception handler table starting from the current position.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort count) == false)
                return false;

            size += count * ExceptionHandler.RecordSize;
            if (reader.TryAdvance(count * ExceptionHandler.RecordSize) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the exception handler table starting from the current position.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="exceptionTable"></param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ExceptionHandlerTable exceptionTable)
        {
            exceptionTable = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var items = count == 0 ? [] : new ExceptionHandler[count];
            for (int i = 0; i < count; i++)
                if (ExceptionHandler.TryRead(ref reader, out items[i]) == false)
                    return false;

            exceptionTable = new ExceptionHandlerTable(items);
            return true;
        }

        /// <summary>
        /// Gets an empty table.
        /// </summary>
        public static readonly ExceptionHandlerTable Empty = new([]);

        readonly ExceptionHandler[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items">The backing array of items.</param>
        internal ExceptionHandlerTable(ExceptionHandler[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the exception handler at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public readonly ref readonly ExceptionHandler this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the exception handler at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        readonly ref readonly ExceptionHandler GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            return ref _items[index];
        }

        /// <summary>
        /// Gets the number of exception handlers.
        /// </summary>
        public readonly int Count => _items?.Length ?? 0;

        /// <summary>
        /// Gets an enumerator over the exception handlers.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Copies the exception handles to the specified encoder, offsetting any relative code locations.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        /// <param name="offset"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ExceptionTableEncoder encoder, int offset)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            foreach (var i in this)
                i.CopyTo(constantView, constantPool, ref encoder, offset);
        }

        /// <inheritdoc />
        readonly IEnumerator<ExceptionHandler> IEnumerable<ExceptionHandler>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ExceptionHandler IReadOnlyList<ExceptionHandler>.this[int index] => this[index];

    }



}
