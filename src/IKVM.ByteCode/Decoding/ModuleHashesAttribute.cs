using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ModuleHashesAttribute(Utf8ConstantHandle Algorithm, ModuleHashTable Hashes)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static ModuleHashesAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
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
            var self = this;
            encoder.ModuleHashes(constantPool.Get(AttributeName.ModuleHashes), constantPool.Get(constantView.Get(Algorithm)), e => self.Hashes.CopyTo(constantView, constantPool, ref e));
        }

    }

}