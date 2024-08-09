using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct AnnotationDefaultAttribute(ElementValue DefaultValue)
    {

        public static AnnotationDefaultAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out AnnotationDefaultAttribute attribute)
        {
            attribute = default;

            if (ElementValue.TryRead(ref reader, out var defaultValue) == false)
                return false;

            attribute = new AnnotationDefaultAttribute(defaultValue);
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="builder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, AttributeTableBuilder builder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var self = this;
            builder.AnnotationDefault(e => self.DefaultValue.EncodeTo(view, pool, ref e));
        }

    }

}
