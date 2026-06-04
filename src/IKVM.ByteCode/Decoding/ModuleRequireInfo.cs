using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded entry from the requires table of a <c>Module</c> attribute.
    /// </summary>
    /// <param name="Module">Handle to the required module constant.</param>
    /// <param name="Flag">Requires flags for this dependency.</param>
    /// <param name="Version">Handle to the required module version string, or a nil handle if no version is specified.</param>
    public readonly record struct ModuleRequireInfo(ModuleConstantHandle Module, ModuleRequiresFlag Flag, Utf8ConstantHandle Version)
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
        /// Gets the required module.
        /// </summary>
        public readonly ModuleConstantHandle Module = Module;

        /// <summary>
        /// Gets the requires flags.
        /// </summary>
        public readonly ModuleRequiresFlag Flag = Flag;

        /// <summary>
        /// Gets the required module version, or a nil handle if not specified.
        /// </summary>
        public readonly Utf8ConstantHandle Version = Version;

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