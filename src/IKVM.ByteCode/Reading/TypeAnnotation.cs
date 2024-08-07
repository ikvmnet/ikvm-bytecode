using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct TypeAnnotation : IReadOnlyList<ElementValuePair>
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

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotation annotation)
        {
            annotation = default;

            if (TypeAnnotationTarget.TryReadData(ref reader, out var target) == false)
                return false;
            if (TypePath.TryRead(ref reader, out var targetPath) == false)
                return false;
            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort pairCount) == false)
                return false;

            var elements = new ElementValuePair[pairCount];
            for (int i = 0; i < pairCount; i++)
                if (ElementValuePair.TryRead(ref reader, out elements[i]) == false)
                    return false;

            annotation = new TypeAnnotation(target, targetPath, new(typeIndex), elements);
            return true;
        }

        readonly TypeAnnotationTarget _target;
        readonly TypePath _targetPath;
        readonly Utf8ConstantHandle _type;
        readonly ElementValuePair[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="items"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal TypeAnnotation(TypeAnnotationTarget target, TypePath targetPath, Utf8ConstantHandle type, ElementValuePair[] items)
        {
            _target = target;
            _targetPath = targetPath;
            _type = type;
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public TypeAnnotationTarget Target => _target;

        public TypePath TargetPath => _targetPath;

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

        /// <inheritdoc />
        IEnumerator<ElementValuePair> IEnumerable<ElementValuePair>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
