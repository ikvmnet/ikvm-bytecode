﻿using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct RuntimeInvisibleAnnotationsAttribute(AnnotationTable Annotations)
    {

        public static RuntimeInvisibleAnnotationsAttribute Nil => default;

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            if (AnnotationTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out RuntimeInvisibleAnnotationsAttribute attribute)
        {
            attribute = default;

            if (AnnotationTable.TryRead(ref reader, out var annotations) == false)
                return false;

            attribute = new RuntimeInvisibleAnnotationsAttribute(annotations);
            return true;
        }

        public readonly AnnotationTable Annotations = Annotations;
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
            encoder.RuntimeInvisibleAnnotations(constantPool.Get(AttributeName.RuntimeInvisibleAnnotations), e => self.Annotations.CopyTo(constantView, constantPool, ref e));
        }

    }

}