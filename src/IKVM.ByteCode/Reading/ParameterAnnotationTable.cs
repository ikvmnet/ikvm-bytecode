﻿using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct ParameterAnnotationTable : IReadOnlyList<ParameterAnnotation>
    {

        public struct Enumerator : IEnumerator<ParameterAnnotation>
        {

            readonly ParameterAnnotation[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ParameterAnnotation[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ParameterAnnotation Current => ref _items[_index];

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
            readonly ParameterAnnotation IEnumerator<ParameterAnnotation>.Current => Current;

        }

        readonly ParameterAnnotation[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal ParameterAnnotationTable(ParameterAnnotation[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the parameter at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly ParameterAnnotation this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets the parameter at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly ParameterAnnotation GetItem(int index) => ref _items[index];

        /// <summary>
        /// Gets the number of parameters.
        /// </summary>
        public readonly int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the parameters.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref ParameterAnnotationTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in this)
                encoder.ParameterAnnotation(e => i.EncodeTo(map, ref e));
        }

        /// <inheritdoc />
        readonly IEnumerator<ParameterAnnotation> IEnumerable<ParameterAnnotation>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ParameterAnnotation IReadOnlyList<ParameterAnnotation>.this[int index] => this[index];

    }



}
