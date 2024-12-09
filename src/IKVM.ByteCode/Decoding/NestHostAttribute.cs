using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct NestHostAttribute(ClassConstantHandle NestHost)
    {

        public static NestHostAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out NestHostAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort hostClassIndex) == false)
                return false;

            attribute = new NestHostAttribute(new ClassConstantHandle(hostClassIndex));
            return true;
        }

        public readonly ClassConstantHandle NestHost = NestHost;
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
            encoder.NestHost(constantPool.Get(AttributeName.NestHost), constantPool.Get(constantView.Get(NestHost)));
        }

    }

}
