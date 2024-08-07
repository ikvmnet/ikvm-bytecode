using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct InterfaceTable : IReadOnlyList<Interface>
    {

        public struct Enumerator : IEnumerator<Interface>
        {

            readonly InterfaceTable _interfaces;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="interfaces"></param>
            internal Enumerator(InterfaceTable interfaces)
            {
                _interfaces = interfaces;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly Interface Current => _interfaces[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _interfaces.Count;
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

        readonly Interface[] _interfaces;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="interfaces"></param>
        internal InterfaceTable(Interface[] interfaces)
        {
            _interfaces = interfaces ?? throw new ArgumentNullException(nameof(interfaces));
        }

        /// <summary>
        /// Gets a reference to the interface for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly ref readonly Interface this[InterfaceHandle handle] => ref GetInterface(handle);

        /// <summary>
        /// Gets a reference to the interface for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        readonly ref readonly Interface GetInterface(InterfaceHandle handle) => ref _interfaces[handle.Index];

        /// <summary>
        /// Gets a reference to the interface for the given handle.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Interface this[int index] => this[new InterfaceHandle((ushort)index)];

        /// <summary>
        /// Gets the number of interfaces.
        /// </summary>
        public readonly int Count => _interfaces.Length;

        /// <summary>
        /// Gets an enumerator over the interfaces.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(this);

        /// <inheritdoc />
        readonly IEnumerator<Interface> IEnumerable<Interface>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
