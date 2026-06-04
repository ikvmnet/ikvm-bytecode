using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>ModuleTarget</c> attribute specifying the target platform of a module.
    /// </summary>
    /// <param name="Target">Handle to the target platform name constant.</param>
    public readonly record struct ModuleTargetAttribute(Utf8ConstantHandle Target)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static ModuleTargetAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="attribute">The decoded attribute.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ModuleTargetAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort target) == false)
                return false;

            attribute = new ModuleTargetAttribute(new(target));
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
        /// Gets the target platform name.
        /// </summary>
        public readonly Utf8ConstantHandle Target = Target;

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
            var self = this;
            encoder.ModuleTarget(constantPool.Get(AttributeName.ModuleTarget), constantPool.Get(constantView.Get(Target)));
        }

    }

}