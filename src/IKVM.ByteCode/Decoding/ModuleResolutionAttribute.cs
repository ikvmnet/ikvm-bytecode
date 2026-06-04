using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>ModuleResolution</c> attribute specifying resolution hints for a module.
    /// </summary>
    /// <param name="Flag">Resolution flags for this module.</param>
    public readonly record struct ModuleResolutionAttribute(ModuleResolutionFlag Flag)
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
        public static bool TryRead(ref ClassFormatReader reader, out ModuleResolutionAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort flag) == false)
                return false;

            attribute = new ModuleResolutionAttribute((ModuleResolutionFlag)flag);
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
        /// Gets the resolution flags.
        /// </summary>
        public readonly ModuleResolutionFlag Flag = Flag;

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
            encoder.ModuleResolution(constantPool.Get(AttributeName.ModuleResolution), Flag);
        }

    }

}
