using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ModuleRequireInfo(ModuleConstantHandle Module, ModuleRequiresFlag Flag, Utf8ConstantHandle Version)
    {

        public readonly ModuleConstantHandle Module = Module;
        public readonly ModuleRequiresFlag Flag = Flag;
        public readonly Utf8ConstantHandle Version = Version;
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
        /// Copies this info to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ModuleRequiresTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.Requires(constantPool.Get(constantView.Get(Module)), Flag, constantPool.Get(constantView.Get(Version)));
        }

    }

}