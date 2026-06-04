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
        /// <param name="reader"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
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
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.ModuleResolution(constantPool.Get(AttributeName.ModuleResolution), Flag);
        }

    }

}
