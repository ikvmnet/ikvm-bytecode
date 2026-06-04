using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>ModulePackages</c> attribute listing all packages in a module.
    /// </summary>
    /// <param name="Packages">Table of package constant handles.</param>
    public readonly record struct ModulePackagesAttribute(PackageConstantHandleTable Packages)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static ModulePackagesAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="attribute">The decoded attribute.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ModulePackagesAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var packages = count == 0 ? [] : new PackageConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort packageIndex) == false)
                    return false;

                packages[i] = new(packageIndex);
            }

            attribute = new ModulePackagesAttribute(new(packages));
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
        /// Gets the table of packages in the module.
        /// </summary>
        public readonly PackageConstantHandleTable Packages = Packages;

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
            encoder.ModulePackages(constantPool.Get(AttributeName.ModulePackages), e => self.CopyTo(constantView, constantPool, ref e));
        }

        /// <summary>
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref PackageConstantTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            Packages.CopyTo(constantView, constantPool, ref encoder);
        }

    }

}