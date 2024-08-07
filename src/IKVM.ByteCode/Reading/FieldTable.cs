﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct FieldTable : IReadOnlyList<Field>
    {

        public struct Enumerator : IEnumerator<Field>
        {

            readonly FieldTable _fields;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="methods"></param>
            internal Enumerator(FieldTable methods)
            {
                _fields = methods;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly Field Current => _fields[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _fields.Count;
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

        readonly Field[] _fields;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="fields"></param>
        internal FieldTable(Field[] fields)
        {
            _fields = fields ?? throw new ArgumentNullException(nameof(fields));
        }

        /// <summary>
        /// Gets a reference to the field for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly ref readonly Field this[FieldHandle handle] => ref GetField(handle);

        /// <summary>
        /// Gets a reference to the field for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        readonly ref readonly Field GetField(FieldHandle handle) => ref _fields[handle.Index];

        /// <summary>
        /// Gets a reference to the field for the given handle.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Field this[int index] => this[new FieldHandle((ushort)index)];

        /// <summary>
        /// Gets the number of fields.
        /// </summary>
        public readonly int Count => _fields.Length;

        /// <summary>
        /// Gets an enumerator over the fields.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(this);

        /// <inheritdoc />
        readonly IEnumerator<Field> IEnumerable<Field>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}