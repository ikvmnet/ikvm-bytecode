using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public readonly struct InterfaceTable : IReadOnlyList<Interface>
    {

        public struct Enumerator : IEnumerator<Interface>
        {

            readonly Interface[] _interfaces;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="interfaces"></param>
            internal Enumerator(Interface[] interfaces)
            {
                _interfaces = interfaces;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ref readonly Interface Current => ref _interfaces[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _interfaces.Length;
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
            readonly Interface IEnumerator<Interface>.Current => Current;

        }

        /// <summary>
        /// Attempts to read the interface table starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        internal static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort count) == false)
                return false;

            for (int i = 0; i < count; i++)
                if (Interface.TryMeasure(ref reader, ref size) == false)
                    return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the interface table starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        internal static bool TryRead(ref ClassFormatReader reader, out InterfaceTable interfaces)
        {
            interfaces = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var items = count == 0 ? [] : new Interface[count];
            for (int i = 0; i < count; i++)
            {
                if (Interface.TryRead(ref reader, out Interface iface) == false)
                    return false;

                items[i] = iface;
            }

            interfaces = new InterfaceTable(items);
            return true;
        }

        public static readonly InterfaceTable Empty = new([]);

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
        public readonly ref readonly Interface this[int index] => ref this[new InterfaceHandle((ushort)index)];

        /// <summary>
        /// Gets the number of interfaces.
        /// </summary>
        public readonly int Count => _interfaces.Length;

        /// <summary>
        /// Gets an enumerator over the interfaces.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_interfaces);

        /// <inheritdoc />
        readonly IEnumerator<Interface> IEnumerable<Interface>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly Interface IReadOnlyList<Interface>.this[int index] => this[index];

    }

}
