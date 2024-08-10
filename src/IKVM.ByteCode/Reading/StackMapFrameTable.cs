using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct StackMapFrameTable : IReadOnlyList<StackMapFrame>
    {

        public struct Enumerator : IEnumerator<StackMapFrame>
        {

            readonly StackMapFrame[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(StackMapFrame[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly StackMapFrame Current => ref _items[_index];

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
            readonly StackMapFrame IEnumerator<StackMapFrame>.Current => Current;

        }

        public static readonly StackMapFrameTable Empty = new([]);

        readonly StackMapFrame[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal StackMapFrameTable(StackMapFrame[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the frame at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly StackMapFrame this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the frame at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly StackMapFrame GetItem(int index) => ref _items[index];

        /// <summary>
        /// Gets the number of frames.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the frames.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<StackMapFrame> IEnumerable<StackMapFrame>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly StackMapFrame IReadOnlyList<StackMapFrame>.this[int index] => this[index];

    }



}
