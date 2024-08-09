using System;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    /// <summary>
    /// Provides an accessor that combines an <see cref="Table"/> with a <see cref="ConstantTable"/> to provide name-based cached lookups of typed attributes.
    /// </summary>
    public partial class AttributeTableReader
    {

        readonly ClassFile _clazz;
        readonly AttributeTable _table;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="attributes"></param>
        public AttributeTableReader(ClassFile clazz, AttributeTable attributes)
        {
            _clazz = clazz ?? throw new ArgumentNullException(nameof(clazz));
            _table = attributes;
        }

        /// <summary>
        /// Gets the original attribute table.
        /// </summary>
        public ref readonly AttributeTable Table => ref _table;

        /// <summary>
        /// Gets the attribute with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Attribute this[string name]
        {
            get
            {
                var attribute = FindByName(name);
                if (attribute.IsNil)
                    throw new KeyNotFoundException($"Attribute with the name {name} not found on attribute table.");

                return attribute;
            }
        }

        /// <summary>
        /// Attempts to get the attribute with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(string name, out Attribute value)
        {
            value = FindByName(name);
            return value.IsNotNil;
        }

        /// <summary>
        /// Scans the attribute table for the matching attribute by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Attribute FindByName(string name)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            foreach (var i in _table)
                if (_clazz.Constants.Get(i.Name) == name)
                    return i;

            return Attribute.Nil;
        }

    }

}
