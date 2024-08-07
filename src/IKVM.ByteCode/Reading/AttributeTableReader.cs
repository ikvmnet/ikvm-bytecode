using System;

namespace IKVM.ByteCode.Reading
{

    /// <summary>
    /// Provides an accessor that combines an <see cref="AttributeTable"/> with a <see cref="ConstantTable"/> to provide name-based cached lookups of typed attributes.
    /// </summary>
    public partial class AttributeTableReader
    {

        readonly ConstantTable _constants;
        readonly AttributeTable _attributes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="attributes"></param>
        public AttributeTableReader(ConstantTable constants, AttributeTable attributes)
        {
            _constants = constants ?? throw new ArgumentNullException(nameof(constants));
            _attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
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

            foreach (var i in _attributes)
                if (i.Name.IsNil == false && _constants.GetUtf8Value(i.Name) == name)
                    return i;

            return Attribute.Nil;
        }

    }

}
