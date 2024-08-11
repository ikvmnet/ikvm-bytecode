using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct AnnotationTable : IReadOnlyList<Annotation>
    {

        public struct Enumerator : IEnumerator<Annotation>
        {

            readonly Annotation[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(Annotation[] items)
            {
                _items = items ?? [];
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly Annotation Current => ref _items[_index];

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
            readonly Annotation IEnumerator<Annotation>.Current => Current;

        }

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort count) == false)
                return false;

            for (int i = 0; i < count; i++)
                if (Annotation.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out AnnotationTable annotations)
        {
            annotations = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var items = count == 0 ? [] : new Annotation[count];
            for (int i = 0; i < count; i++)
            {
                if (Annotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                items[i] = annotation;
            }

            annotations = new AnnotationTable(items);
            return true;
        }

        public static readonly AnnotationTable Empty = new([]);

        readonly Annotation[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal AnnotationTable(Annotation[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the annotation at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly Annotation this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the annotation at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly Annotation GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            return ref _items[index];
        }

        /// <summary>
        /// Gets the number of annotations.
        /// </summary>
        public readonly int Count => _items?.Length ?? 0;

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => _items == null;

        /// <summary>
        /// Gets whether or not this does not represent the nil instance.
        /// </summary>
        public readonly bool IsNotNil => !IsNil;

        /// <summary>
        /// Gets an enumerator over the annotations.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref AnnotationTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in this)
                encoder.Annotation(e => i.EncodeTo(map, ref e));
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref AnnotationTableEncoder encoder)
        {
            foreach (var i in this)
                encoder.Annotation(e => i.WriteTo(ref e));
        }

        /// <inheritdoc />
        readonly IEnumerator<Annotation> IEnumerable<Annotation>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly Annotation IReadOnlyList<Annotation>.this[int index] => this[index];

    }

}
