using System;

namespace IKVM.ByteCode.Reading
{

    /// <summary>
    /// Provides an accessor that combines an <see cref="AttributeTable"/> with a <see cref="ConstantTable"/> to provide name-based cached lookups of typed attributes.
    /// </summary>
    public partial class AttributeTableReader
    {

        readonly ClassFile _clazz;
        readonly AttributeTable _attributes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="attributes"></param>
        public AttributeTableReader(ClassFile clazz, AttributeTable attributes)
        {
            _clazz = clazz ?? throw new ArgumentNullException(nameof(clazz));
            _attributes = attributes;
        }

        /// <summary>
        /// Gets the original attribute table.
        /// </summary>
        public ref readonly AttributeTable AttributeTable => ref _attributes;

        /// <summary>
        /// Scans the attribute table for the matching attribute by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Attribute FindByName(string name)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            foreach (var i in _attributes)
                if (_clazz.Constants.Get(i.Name) == name)
                    return i;

            return Attribute.Nil;
        }

    }

}
