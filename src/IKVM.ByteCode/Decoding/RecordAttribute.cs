using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>Record</c> attribute describing the components of a record class.
    /// </summary>
    /// <param name="Components">Table of record component entries.</param>
    public readonly record struct RecordAttribute(RecordComponentTable Components)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static RecordAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="attribute">The decoded attribute.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
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
        /// Gets the table of record components.
        /// </summary>
        public readonly RecordComponentTable Components = Components;

        /// <summary>
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Record(constantPool.Get(AttributeName.Record), e => self.Components.CopyTo(constantView, constantPool, ref e));
        }

    }

}
