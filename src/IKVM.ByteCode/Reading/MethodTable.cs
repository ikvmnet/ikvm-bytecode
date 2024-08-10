using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct MethodTable : IReadOnlyList<Method>
    {

        public struct Enumerator : IEnumerator<Method>
        {

            readonly Method[] _methods;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="methods"></param>
            internal Enumerator(Method[] methods)
            {
                _methods = methods;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly Method Current => ref _methods[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _methods.Length;
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
            readonly Method IEnumerator<Method>.Current => Current;

        }

        public static readonly MethodTable Empty = new([]);

        readonly Method[] _methods;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="methods"></param>
        internal MethodTable(Method[] methods)
        {
            _methods = methods ?? throw new ArgumentNullException(nameof(methods));
        }

        /// <summary>
        /// Gets a reference to the method reader for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly ref readonly Method this[MethodHandle handle] => ref GetMethod(handle);

        /// <summary>
        /// Gets a reference to the method reader for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        readonly ref readonly Method GetMethod(MethodHandle handle) => ref _methods[handle.Index];

        /// <summary>
        /// Gets a reference to the method reader for the given handle.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public readonly ref readonly Method this[int index] => ref this[new MethodHandle((ushort)index)];

        /// <summary>
        /// Gets the number of methods.
        /// </summary>
        public readonly int Count => _methods.Length;

        /// <summary>
        /// Gets an enumerator over the methods.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_methods);

        /// <inheritdoc />
        readonly IEnumerator<Method> IEnumerable<Method>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly Method IReadOnlyList<Method>.this[int index] => this[index];

    }

}
