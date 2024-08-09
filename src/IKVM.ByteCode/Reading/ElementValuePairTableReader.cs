using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public class ElementValuePairTableReader : IReadOnlyDictionary<string, ElementValue>
    {

        readonly ClassFile _clazz;
        readonly ElementValuePairTable _table;
        readonly ConcurrentDictionary<string, ElementValue> _cache = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="annotation"></param>
        public ElementValuePairTableReader(ClassFile clazz, ElementValuePairTable annotation)
        {
            _clazz = clazz ?? throw new ArgumentNullException(nameof(clazz));
            _table = annotation;
        }

        /// <summary>
        /// Gets the original table.
        /// </summary>
        public ref readonly ElementValuePairTable Table => ref _table;

        /// <inheritdoc />
        public ElementValue this[string key]
        {
            get
            {
                var value = _cache.GetOrAdd(key, FindByName);
                if (value.IsNil)
                    throw new IndexOutOfRangeException();

                return value;
            }
        }

        /// <summary>
        /// Scans the annotation for a matching element value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ElementValue FindByName(string name)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            foreach (var elementValuePair in _table)
                if (_clazz.Constants.Get(elementValuePair.Name) == name)
                    return elementValuePair.Value;

            return ElementValue.Nil;
        }

        /// <inheritdoc />
        public IEnumerable<string> Keys
        {
            get
            {
                foreach (var elementValuePair in _table)
                {
                    var name = _clazz.Constants.Get(elementValuePair.Name);
                    if (name.IsNil)
                        throw new InvalidClassException("ElementValuePair with null name entry encountered.");

                    yield return name.Value;
                }
            }
        }

        /// <inheritdoc />
        public IEnumerable<ElementValue> Values
        {
            get
            {
                foreach (var elementValuePair in _table)
                    yield return elementValuePair.Value;
            }
        }

        /// <inheritdoc />
        public int Count => _table.Count;

        /// <inheritdoc />
        public bool ContainsKey(string key) => _cache.ContainsKey(key) || FindByName(key).IsNotNil;

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, ElementValue>> GetEnumerator()
        {
            foreach (var elementValuePair in _table)
            {
                var name = _clazz.Constants.Get(elementValuePair.Name);
                if (name.IsNil)
                    throw new InvalidClassException("ElementValuePair with null name entry encountered.");

                yield return new KeyValuePair<string, ElementValue>(name.Value, elementValuePair.Value);
            }
        }

        /// <inheritdoc />
        public bool TryGetValue(string key, out ElementValue value)
        {
            value = FindByName(key);
            return value.IsNotNil;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
