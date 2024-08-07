#pragma warning disable 0282

using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    /// <summary>
    /// Table of attribute data.
    /// </summary>
    public partial class AttributeTable : IReadOnlyCollection<Attribute>
    {

        public struct Enumerator : IEnumerator<Attribute>
        {

            readonly AttributeTable _attributes;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="methods"></param>
            internal Enumerator(AttributeTable methods)
            {
                _attributes = methods;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly Attribute Current => _attributes[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _attributes.Count;
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

        readonly Attribute[] _attributes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        /// <param name="attributes"></param>
        internal AttributeTable(Attribute[] attributes)
        {
            _attributes = attributes;
        }

        /// <summary>
        /// Gets a reference to the attribute at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Attribute this[int index] => GetAttribute(index);

        /// <summary>
        /// Gets the attribute at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Attribute GetAttribute(int index) => _attributes[index];

        /// <summary>
        /// Gets the number of fields.
        /// </summary>
        public int Count => _attributes.Length;

        /// <summary>
        /// Gets an enumerator over the fields.
        /// </summary>
        public Enumerator GetEnumerator() => new Enumerator(this);

        /// <inheritdoc />
        IEnumerator<Attribute> IEnumerable<Attribute>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
