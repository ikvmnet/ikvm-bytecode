using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public class AnnotationReader : IReadOnlyDictionary<string, ElementValue>
    {

        readonly ClassFile _clazz;
        readonly Annotation _annotation;
        readonly ConcurrentDictionary<string, ElementValue> _cache = new ConcurrentDictionary<string, ElementValue>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="annotation"></param>
        public AnnotationReader(ClassFile clazz, Annotation annotation)
        {
            _clazz = clazz ?? throw new ArgumentNullException(nameof(clazz));
            _annotation = annotation;
        }

        /// <summary>
        /// Gets the original annotation.
        /// </summary>
        public ref readonly Annotation Annotation => ref _annotation;

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

            foreach (var elementValuePair in _annotation)
                if (_clazz.GetUtf8Value(elementValuePair.Name) == name)
                    return elementValuePair.Value;

            return ElementValue.Nil;
        }

        /// <inheritdoc />
        public IEnumerable<string> Keys
        {
            get
            {
                foreach (var elementValuePair in _annotation)
                    yield return _clazz.GetUtf8Value(elementValuePair.Name);
            }
        }

        /// <inheritdoc />
        public IEnumerable<ElementValue> Values
        {
            get
            {
                foreach (var elementValuePair in _annotation)
                    yield return elementValuePair.Value;
            }
        }

        /// <inheritdoc />
        public int Count => _annotation.Count;

        /// <inheritdoc />
        public bool ContainsKey(string key) => _cache.ContainsKey(key) || FindByName(key).IsNotNil;

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, ElementValue>> GetEnumerator()
        {
            foreach (var elementValuePair in _annotation)
                yield return new KeyValuePair<string, ElementValue>(_clazz.GetUtf8Value(elementValuePair.Name), elementValuePair.Value);
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
