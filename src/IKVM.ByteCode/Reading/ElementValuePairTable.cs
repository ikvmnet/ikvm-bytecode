using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ElementValuePairTable : IReadOnlyList<ElementValuePair>
    {

        public struct Enumerator : IEnumerator<ElementValuePair>
        {

            readonly ElementValuePair[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ElementValuePair[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ElementValuePair Current => ref _items[_index];

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
            readonly ElementValuePair IEnumerator<ElementValuePair>.Current => Current;

        }

        /// <summary>
        /// Measures the size of the current annotation.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;

            if (reader.TryReadU2(out ushort pairCount) == false)
                return false;

            for (int i = 0; i < pairCount; i++)
                if (ElementValuePair.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        /// <summary>
        /// Attempts to read an annotation.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="annotation"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out ElementValuePairTable annotation)
        {
            annotation = default;

            if (reader.TryReadU2(out ushort pairCount) == false)
                return false;

            var elements = new ElementValuePair[pairCount];
            for (int i = 0; i < pairCount; i++)
            {
                if (ElementValuePair.TryRead(ref reader, out var element) == false)
                    return false;

                elements[i] = element;
            }

            annotation = new ElementValuePairTable(elements);
            return true;
        }

        readonly ElementValuePair[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ElementValuePairTable(ElementValuePair[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the element value pair at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ElementValuePair this[int index] => Get(index);

        /// <summary>
        /// Gets the element value pair at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ElementValuePair Get(int index) => _items[index];

        /// <summary>
        /// Gets the number of element values.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the element values.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Imports a <see cref="Annotation"/>.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref ElementValuePairTableEncoder encoder)
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
        readonly IEnumerator<ElementValuePair> IEnumerable<ElementValuePair>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
