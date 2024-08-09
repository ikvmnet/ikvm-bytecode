using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct Annotation : IReadOnlyList<ElementValuePair>
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
            public readonly ElementValuePair Current => _items[_index];

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

        /// <summary>
        /// Measures the size of the current annotation.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2 + ClassFormatReader.U2;

            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;
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
        public static bool TryRead(ref ClassFormatReader reader, out Annotation annotation)
        {
            annotation = default;

            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort pairCount) == false)
                return false;

            var elements = new ElementValuePair[pairCount];
            for (int i = 0; i < pairCount; i++)
            {
                if (ElementValuePair.TryRead(ref reader, out var element) == false)
                    return false;

                elements[i] = element;
            }

            annotation = new Annotation(new(typeIndex), elements);
            return true;
        }

        readonly Utf8ConstantHandle _type;
        readonly ElementValuePair[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="items"></param>
        internal Annotation(Utf8ConstantHandle type, ElementValuePair[] items)
        {
            _type = type;
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets the type of the annotation.
        /// </summary>
        public Utf8ConstantHandle Type => _type;

        /// <summary>
        /// Gets a reference to the element value pair at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ElementValuePair this[int index] => GetAttribute(index);

        /// <summary>
        /// Gets the element value pair at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ElementValuePair GetAttribute(int index) => _items[index];

        /// <summary>
        /// Gets the number of element values.
        /// </summary>
        public int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the element values.
        /// </summary>
        public Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Imports a <see cref="Annotation"/>.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref AnnotationEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var self = this;
            encoder.Annotation(pool.Import(view, Type), e =>
            {
                foreach (var i in self)
                    i.EncodeTo(view, pool, ref e);
            });
        }

        /// <inheritdoc />
        IEnumerator<ElementValuePair> IEnumerable<ElementValuePair>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
