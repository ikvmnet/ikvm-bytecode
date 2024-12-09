using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct RecordComponent(Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeTable Attributes)
    {

        public static RecordComponent Nil => default;

        public readonly Utf8ConstantHandle Name = Name;
        public readonly Utf8ConstantHandle Descriptor = Descriptor;
        public readonly AttributeTable Attributes = Attributes;
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
