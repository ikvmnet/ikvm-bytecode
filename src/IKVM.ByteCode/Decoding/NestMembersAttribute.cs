﻿using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct NestMembersAttribute(ClassConstantHandleTable NestMembers)
    {

        public static bool TryRead(ref ClassFormatReader reader, out NestMembersAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var classes = count == 0 ? [] : new ClassConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort classIndex) == false)
                    return false;

                classes[i] = new(classIndex);
            }

            attribute = new NestMembersAttribute(new(classes));
            return true;
        }

        public readonly ClassConstantHandleTable NestMembers = NestMembers;
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
            encoder.NestMembers(constantPool.Get(AttributeName.NestMembers), e => self.CopyTo(constantView, constantPool, ref e));
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool,ref ClassConstantTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            NestMembers.CopyTo(constantView, constantPool, ref encoder);
        }

    }

}
