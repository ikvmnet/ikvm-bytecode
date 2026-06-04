using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the decoded <c>ConstantValue</c> attribute of a class file field.
    /// </summary>
    /// <param name="Value">The constant pool handle to the constant value.</param>
    public readonly record struct ConstantValueAttribute(ConstantHandle Value)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static ConstantValueAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="attribute">The decoded attribute on success.</param>
        /// <returns><see langword="true"/> if the attribute was read successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ConstantValueAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort valueIndex) == false)
                return false;

            attribute = new ConstantValueAttribute(new ConstantHandle(ConstantKind.Unknown, valueIndex));
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
        /// Gets the constant pool handle to the constant value.
        /// </summary>
        public readonly ConstantHandle Value = Value;

        /// <summary>
        /// Copies this attribute to the specified encoder.
        /// </summary>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.ConstantValue(constantPool.Get(AttributeName.ConstantValue), constantPool.Get(constantView.Get(Value)));
        }

    }

}
