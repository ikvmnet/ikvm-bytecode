using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded record component entry from the <c>Record</c> attribute.
    /// </summary>
    /// <param name="Name">Handle to the component name constant.</param>
    /// <param name="Descriptor">Handle to the component descriptor constant.</param>
    /// <param name="Attributes">Attribute table associated with this component.</param>
    public readonly record struct RecordComponent(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeTable Attributes)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static RecordComponent Nil => default;

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
        /// Gets the component name.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

        /// <summary>
        /// Gets the component descriptor.
        /// </summary>
        public readonly Utf8ConstantHandle Descriptor = Descriptor;

        /// <summary>
        /// Gets the component attributes.
        /// </summary>
        public readonly AttributeTable Attributes = Attributes;

        /// <summary>
        /// Copies this component to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref RecordComponentTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.RecordComponent(constantPool.Get(constantView.Get(Name)), constantPool.Get(constantView.Get(Descriptor)), e => self.Attributes.CopyTo(constantView, constantPool, ref e));
        }

    }

}
