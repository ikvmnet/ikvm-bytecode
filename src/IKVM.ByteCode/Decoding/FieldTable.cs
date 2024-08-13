using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Decoding
{

    public readonly struct FieldTable : IReadOnlyList<Field>
    {

        public struct Enumerator : IEnumerator<Field>
        {

            readonly Field[] _fields;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="fields"></param>
            internal Enumerator(Field[] fields)
            {
                _fields = fields;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly Field Current => ref _fields[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _fields.Length;
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
            readonly Field IEnumerator<Field>.Current => Current;

        }

        /// <summary>
        /// Attempts to read the set of fields starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort count) == false)
                return false;

            for (int i = 0; i < count; i++)
                if (Field.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the set of fields starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        internal static bool TryRead(ref ClassFormatReader reader, out FieldTable fields)
        {
            fields = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var items = count == 0 ? [] : new Field[count];
            for (int i = 0; i < count; i++)
            {
                if (Field.TryRead(ref reader, out var field) == false)
                    return false;

                items[i] = field;
            }

            fields = new FieldTable(items);
            return true;
        }

        public static readonly FieldTable Empty = new([]);

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
        public readonly ref readonly Field this[int index] => ref this[new FieldHandle((ushort)index)];

        /// <summary>
        /// Gets the number of fields.
        /// </summary>
        public readonly int Count => _fields.Length;

        /// <summary>
        /// Gets an enumerator over the fields.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_fields);

        /// <inheritdoc />
        readonly IEnumerator<Field> IEnumerable<Field>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly Field IReadOnlyList<Field>.this[int index] => this[index];

    }

}
