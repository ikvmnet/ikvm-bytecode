using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct RecordAttribute(RecordComponentTable Components)
    {

        public static RecordAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out RecordAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort componentsCount) == false)
                return false;

            var components = componentsCount == 0 ? [] : new RecordComponent[componentsCount];
            for (int i = 0; i < componentsCount; i++)
            {
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort descriptorIndex) == false)
                    return false;
                if (ClassFile.TryReadAttributeTable(ref reader, out var attributes) == false)
                    return false;

                components[i] = new RecordComponent(new(nameIndex), new(descriptorIndex), attributes);
            }

            attribute = new RecordAttribute(new(components));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="attributeName"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.Record(attributeName, e => self.Components.EncodeTo(map, ref e));
        }

    }

}
