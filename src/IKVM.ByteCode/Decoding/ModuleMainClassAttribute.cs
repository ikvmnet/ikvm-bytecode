using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>ModuleMainClass</c> attribute identifying the main class of a module.
    /// </summary>
    /// <param name="MainClass">Handle to the main class constant.</param>
    public readonly record struct ModuleMainClassAttribute(ClassConstantHandle MainClass)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static ModuleMainClassAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="attribute">The decoded attribute.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ModuleMainClassAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort mainClassIndex) == false)
                return false;

            attribute = new ModuleMainClassAttribute(new ClassConstantHandle(mainClassIndex));
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
        /// Gets the main class of the module.
        /// </summary>
        public readonly ClassConstantHandle MainClass = MainClass;

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
            encoder.ModuleMainClass(constantPool.Get(AttributeName.ModuleMainClass), constantPool.Get(constantView.Get(MainClass)));
        }

    }

}
