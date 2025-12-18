using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ConstantValueAttribute(ConstantHandle Value)
    {

        public static ConstantValueAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ConstantValueAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort valueIndex) == false)
                return false;

            attribute = new ConstantValueAttribute(new ConstantHandle(ConstantKind.Unknown, valueIndex));
            return true;
        }

        public readonly ConstantHandle Value = Value;
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
