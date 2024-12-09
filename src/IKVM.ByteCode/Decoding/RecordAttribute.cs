using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
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
                if (AttributeTable.TryRead(ref reader, out var attributes) == false)
                    return false;

                components[i] = new RecordComponent(new(nameIndex), new(descriptorIndex), attributes);
            }

            attribute = new RecordAttribute(new(components));
            return true;
        }

        public readonly RecordComponentTable Components = Components;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Record(constantPool.Get(AttributeName.Record), e => self.Components.CopyTo(constantView, constantPool, ref e));
        }

    }

}
