﻿using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly struct TypePath : IReadOnlyList<TypePathComponent>
    {

        public struct Enumerator : IEnumerator<TypePathComponent>
        {

            readonly TypePathComponent[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(TypePathComponent[] items)
            {
                _items = items ?? [];
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly TypePathComponent Current => ref _items[_index];

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
            readonly TypePathComponent IEnumerator<TypePathComponent>.Current => Current;

        }

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U1;
            if (reader.TryReadU1(out byte length) == false)
                return false;

            for (int i = 0; i < length; i++)
                if (TypePathComponent.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out TypePath typePath)
        {
            typePath = default;

            if (reader.TryReadU1(out byte length) == false)
                return false;

            var path = length == 0 ? [] : new TypePathComponent[length];
            for (int i = 0; i < length; i++)
            {
                if (TypePathComponent.TryRead(ref reader, out var item) == false)
                    return false;

                path[i] = item;
            }

            typePath = new TypePath(path);
            return true;
        }

        readonly TypePathComponent[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        internal TypePath(TypePathComponent[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets a reference to the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly TypePathComponent this[int index] => ref GetItem(index);

        /// <summary>
        /// Gets a reference to the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly TypePathComponent GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            return ref _items[index];
        }

        /// <summary>
        /// Gets the number of items.
        /// </summary>
        public readonly int Count => _items?.Length ?? 0;

        /// <summary>
        /// Gets an enumerator over the items.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Copies this path to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref TypePathEncoder encoder)
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
        public readonly void WriteTo(ref TypePathEncoder encoder)
        {
            foreach (var i in this)
                i.WriteTo(ref encoder);
        }

        /// <inheritdoc />
        readonly IEnumerator<TypePathComponent> IEnumerable<TypePathComponent>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly TypePathComponent IReadOnlyList<TypePathComponent>.this[int index] => this[index];

    }

}
