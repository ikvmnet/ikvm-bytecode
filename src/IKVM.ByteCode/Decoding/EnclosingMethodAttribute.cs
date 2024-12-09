using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct EnclosingMethodAttribute(ClassConstantHandle Class, NameAndTypeConstantHandle Method)
    {

        public static EnclosingMethodAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out EnclosingMethodAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort methodIndex) == false)
                return false;

            attribute = new EnclosingMethodAttribute(new(classIndex), new(methodIndex));
            return true;
        }

        public readonly ClassConstantHandle Class = Class;
        public readonly NameAndTypeConstantHandle Method = Method;
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
            encoder.EnclosingMethod(constantPool.Get(AttributeName.EnclosingMethod), constantPool.Get(constantView.Get(Class)), constantPool.Get(constantView.Get(Method)));
        }

    }

}
