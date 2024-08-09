﻿using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct DeprecatedAttribute()
    {

        public static DeprecatedAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out DeprecatedAttribute attribute)
        {
            attribute = new DeprecatedAttribute();
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

            builder.Deprecated();
        }

    }

}