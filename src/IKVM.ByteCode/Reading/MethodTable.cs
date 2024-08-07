using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct MethodTable : IReadOnlyList<Method>
    {

        public struct Enumerator : IEnumerator<Method>
        {

            readonly MethodTable _methods;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="methods"></param>
            internal Enumerator(MethodTable methods)
            {
                _methods = methods;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly Method Current => _methods[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _methods.Count;
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
        public Method this[int index] => this[new MethodHandle((ushort)index)];

        /// <summary>
        /// Gets the number of methods.
        /// </summary>
        public readonly int Count => _methods.Length;

        /// <summary>
        /// Gets an enumerator over the methods.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(this);

        /// <inheritdoc />
        readonly IEnumerator<Method> IEnumerable<Method>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
