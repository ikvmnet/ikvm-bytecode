using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>Signature</c> attribute containing the generic signature of a class, field, or method.
    /// </summary>
    /// <param name="Signature">Handle to the signature string constant.</param>
    public readonly record struct SignatureAttribute(Utf8ConstantHandle Signature)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static SignatureAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="attribute">The decoded attribute.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out SignatureAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort signatureIndex) == false)
                return false;

            attribute = new SignatureAttribute(new Utf8ConstantHandle(signatureIndex));
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
        /// Gets the generic signature string.
        /// </summary>
        public readonly Utf8ConstantHandle Signature = Signature;

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
            encoder.Signature(constantPool.Get(AttributeName.Signature), constantPool.Get(constantView.Get(Signature)));
        }

    }

}