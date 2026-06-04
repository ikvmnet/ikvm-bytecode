using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded entry from the exports table of a <c>Module</c> attribute.
    /// </summary>
    /// <param name="Package">Handle to the exported package constant.</param>
    /// <param name="Flags">Export access flags.</param>
    /// <param name="Modules">Table of module handles to which this package is exported, or empty for unqualified export.</param>
    public readonly record struct ModuleExportInfo(PackageConstantHandle Package, ModuleExportsFlag Flags, ModuleConstantHandleTable Modules)
    {

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
        /// Gets the exported package.
        /// </summary>
        public readonly PackageConstantHandle Package = Package;

        /// <summary>
        /// Gets the export flags.
        /// </summary>
        public readonly ModuleExportsFlag Flags = Flags;

        /// <summary>
        /// Gets the modules to which the package is exported.
        /// </summary>
        public readonly ModuleConstantHandleTable Modules = Modules;

        /// <summary>
        /// Copies this info to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ModuleExportsTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Exports(constantPool.Get(constantView.Get(Package)), Flags, e => Encode(self.Modules, ref e));

            void Encode(in ModuleConstantHandleTable table, ref ModuleTableEncoder e)
            {
                foreach (var i in table)
                    e.Module(constantPool.Get(constantView.Get(i)));
            }
        }

    }

}
