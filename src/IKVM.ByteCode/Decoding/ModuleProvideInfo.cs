using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded entry from the provides table of a <c>Module</c> attribute.
    /// </summary>
    /// <param name="Class">Handle to the service interface or abstract class.</param>
    /// <param name="With">Table of implementation class handles.</param>
    public readonly record struct ModuleProvideInfo(ClassConstantHandle Class, ClassConstantHandleTable With)
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
        /// Gets the service type.
        /// </summary>
        public readonly ClassConstantHandle Class = Class;

        /// <summary>
        /// Gets the service implementations.
        /// </summary>
        public readonly ClassConstantHandleTable With = With;

        /// <summary>
        /// Copies this info to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ModuleProvidesTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Provides(constantPool.Get(constantView.Get(Class)), e => self.With.CopyTo(constantView, constantPool, ref e));
        }

    }

}
