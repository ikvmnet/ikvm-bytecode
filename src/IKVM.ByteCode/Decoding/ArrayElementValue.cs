using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ArrayElementValue : IReadOnlyList<ElementValue>
    {

        public struct Enumerator : IEnumerator<ElementValue>
        {

            readonly ElementValue[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ElementValue[] items)
            {
                _items = items ?? [];
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly ElementValue Current => ref _items[_index];

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
            readonly ElementValue IEnumerator<ElementValue>.Current => Current;

        }

        /// <summary>
        /// Measures the size of the current element value array.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort length) == false)
                return false;

            for (int i = 0; i < length; i++)
                if (ElementValue.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        /// <summary>
        /// Reads the data of the current element value array.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data)
        {
            data = default;

            int size = 0;
            if (TryMeasure(ref reader, ref size) == false)
                return false;

            // rewind after measure to read data
            reader.Rewind(size);
            if (reader.TryReadMany(size, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the data of the array.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out ArrayElementValue value)
        {
            value = default;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var values = new ElementValue[length];
            for (int i = 0; i < length; i++)
            {
                if (ElementValue.TryRead(ref reader, out var j) == false)
                    return false;

                values[i] = j;
            }

            value = new ArrayElementValue(values);
            return true;
        }

        readonly ElementValue[] _items;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal ArrayElementValue(ElementValue[] values)
        {
            _items = values ?? throw new ArgumentNullException(nameof(values));
        }

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Gets a reference to the value for the given index.
        /// </summary>
        /// <param name="index"></param> 
        /// <returns></returns>
        public readonly ref readonly ElementValue this[int index] => ref GetItem(index);

        /// <summary>r
        /// Gets a reference to the values for the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        readonly ref readonly ElementValue GetItem(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            return ref _items[index];
        }

        /// <summary>
        /// Gets the number of values.
        /// </summary>
        public readonly int Count => _items != null ? _items.Length : 0;

        /// <summary>
        /// Gets an enumerator over the values.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <inheritdoc />
        readonly IEnumerator<ElementValue> IEnumerable<ElementValue>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly ElementValue IReadOnlyList<ElementValue>.this[int index] => this[index];

    }


}
