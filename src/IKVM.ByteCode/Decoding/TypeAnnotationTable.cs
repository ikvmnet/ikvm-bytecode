using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly struct TypeAnnotationTable : IReadOnlyList<TypeAnnotation>
    {

        public struct Enumerator : IEnumerator<TypeAnnotation>
        {

            readonly TypeAnnotation[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(TypeAnnotation[] items)
            {
                _items = items ?? [];
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly TypeAnnotation Current => ref _items[_index];

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
            readonly TypeAnnotation IEnumerator<TypeAnnotation>.Current => Current;

        }

        /// <summary>
        /// Attempts to measure the size taken by the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort count) == false)
                return false;

            for (int i = 0; i < count; i++)
                if (TypeAnnotation.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="annotations"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTable annotations)
        {
            annotations = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var items = count == 0 ? [] : new TypeAnnotation[count];
            for (int i = 0; i < count; i++)
            {
                if (TypeAnnotation.TryRead(ref reader, out var annotation) == false)
                    return false;

                items[i] = annotation;
            }

            annotations = new TypeAnnotationTable(items);
            return true;
        }

        /// <summary>
        /// Gets an empty table.
        /// </summary>
        public static readonly TypeAnnotationTable Empty = new([]);

        readonly TypeAnnotation[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal TypeAnnotationTable(TypeAnnotation[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly TypeAnnotation this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets a reference to the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly TypeAnnotation GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            return ref _items[index];
        }

        /// <summary>
        /// Gets the number of type annotations.
        /// </summary>
        public readonly int Count => _items?.Length ?? 0;

        /// <summary>
        /// Gets an enumerator over the type annotations.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Copies this table to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref TypeAnnotationTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            foreach (var i in this)
                i.CopyTo(constantView, constantPool, ref encoder);
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref TypeAnnotationTableEncoder encoder)
        {
            foreach (var i in this)
                i.WriteTo(ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<TypeAnnotation> IEnumerable<TypeAnnotation>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly TypeAnnotation IReadOnlyList<TypeAnnotation>.this[int index] => this[index];

    }



}
