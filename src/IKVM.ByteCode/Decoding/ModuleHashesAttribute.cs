using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>ModuleHashes</c> attribute containing cryptographic hashes of module dependencies.
    /// </summary>
    /// <param name="Algorithm">Handle to the hash algorithm name constant.</param>
    /// <param name="Hashes">Table of module hash entries.</param>
    public readonly record struct ModuleHashesAttribute(Utf8ConstantHandle Algorithm, ModuleHashTable Hashes)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static ModuleHashesAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="attribute">The decoded attribute.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ModuleHashesAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out var algorithm) == false)
                return false;

            if (ModuleHashTable.TryRead(ref reader, out var hashes) == false)
                return false;

            attribute = new ModuleHashesAttribute(new(algorithm), hashes);
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
        /// Gets the hash algorithm name.
        /// </summary>
        public readonly Utf8ConstantHandle Algorithm = Algorithm;

        /// <summary>
        /// Gets the table of module hashes.
        /// </summary>
        public readonly ModuleHashTable Hashes = Hashes;

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
            encoder.ModuleHashes(constantPool.Get(AttributeName.ModuleHashes), constantPool.Get(constantView.Get(Algorithm)), e => self.Hashes.CopyTo(constantView, constantPool, ref e));
        }

    }

}