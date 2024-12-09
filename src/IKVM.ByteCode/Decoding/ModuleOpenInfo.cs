using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ModuleOpenInfo(PackageConstantHandle Package, ModuleOpensFlag Flags, ModuleConstantHandleTable Modules)
    {

        public readonly PackageConstantHandle Package = Package;
        public readonly ModuleOpensFlag Flags = Flags;
        public readonly ModuleConstantHandleTable Modules = Modules;
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
