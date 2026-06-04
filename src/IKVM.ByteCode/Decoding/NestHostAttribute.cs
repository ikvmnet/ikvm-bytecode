using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>NestHost</c> attribute identifying the top-level host class of a nest.
    /// </summary>
    /// <param name="NestHost">Handle to the nest host class constant.</param>
    public readonly record struct NestHostAttribute(ClassConstantHandle NestHost)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static NestHostAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out NestHostAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort hostClassIndex) == false)
                return false;

            attribute = new NestHostAttribute(new ClassConstantHandle(hostClassIndex));
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
        /// Gets the nest host class.
        /// </summary>
        public readonly ClassConstantHandle NestHost = NestHost;

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
