using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded entry from the opens table of a <c>Module</c> attribute.
    /// </summary>
    /// <param name="Package">Handle to the opened package constant.</param>
    /// <param name="Flags">Opens access flags.</param>
    /// <param name="Modules">Table of module handles to which this package is opened, or empty for unqualified open.</param>
    public readonly record struct ModuleOpenInfo(PackageConstantHandle Package, ModuleOpensFlag Flags, ModuleConstantHandleTable Modules)
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
        /// Gets the opened package.
        /// </summary>
        public readonly PackageConstantHandle Package = Package;

        /// <summary>
        /// Gets the opens flags.
        /// </summary>
        public readonly ModuleOpensFlag Flags = Flags;

        /// <summary>
        /// Gets the modules to which the package is opened.
        /// </summary>
        public readonly ModuleConstantHandleTable Modules = Modules;

        /// <summary>
        /// Copes this info to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ModuleOpensTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Opens(constantPool.Get(constantView.Get(Package)), Flags, e => Encode(self.Modules, ref e));

            void Encode(in ModuleConstantHandleTable table, ref ModuleTableEncoder e)
            {
                foreach (var i in table)
                    e.Module(constantPool.Get(constantView.Get(i)));
            }
        }

    }

}
