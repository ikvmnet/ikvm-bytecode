using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the decoded <c>EnclosingMethod</c> attribute of a class file.
    /// </summary>
    /// <param name="Class">The constant pool handle to the innermost enclosing class.</param>
    /// <param name="Method">The constant pool handle to the enclosing method name and type, or the nil handle if the class is not immediately enclosed by a method.</param>
    public readonly record struct EnclosingMethodAttribute(ClassConstantHandle Class, NameAndTypeConstantHandle Method)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static EnclosingMethodAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="attribute">The decoded attribute on success.</param>
        /// <returns><see langword="true"/> if the attribute was read successfully; otherwise <see langword="false"/>.</returns>
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
        /// Gets the constant pool handle to the innermost enclosing class.
        /// </summary>
        public readonly ClassConstantHandle Class = Class;

        /// <summary>
        /// Gets the constant pool handle to the enclosing method name and type, or the nil handle if the class is not immediately enclosed by a method.
        /// </summary>
        public readonly NameAndTypeConstantHandle Method = Method;

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
