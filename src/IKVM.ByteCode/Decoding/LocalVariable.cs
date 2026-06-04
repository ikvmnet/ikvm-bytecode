using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a local variable entry decoded from the <c>LocalVariableTable</c> attribute.
    /// </summary>
    /// <param name="StartPc">The bytecode offset at which the local variable scope begins.</param>
    /// <param name="Length">The length in bytes of the local variable's scope.</param>
    /// <param name="Name">The constant pool handle to the local variable name.</param>
    /// <param name="Descriptor">The constant pool handle to the local variable descriptor.</param>
    /// <param name="Slot">The local variable slot index in the frame.</param>
    public readonly record struct LocalVariable(ushort StartPc, ushort Length, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, ushort Slot)
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
        /// Gets the bytecode offset at which the local variable scope begins.
        /// </summary>
        public readonly ushort StartPc = StartPc;

        /// <summary>
        /// Gets the length in bytes of the local variable's scope.
        /// </summary>
        public readonly ushort Length = Length;
        public readonly Utf8ConstantHandle Name = Name;
        public readonly Utf8ConstantHandle Descriptor = Descriptor;
        public readonly ushort Slot = Slot;

        /// <summary>
        /// Copies this variable to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref LocalVariableTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.LocalVariable(StartPc, Length, constantPool.Get(constantView.Get(Name)), constantPool.Get(constantView.Get(Descriptor)), Slot);
        }

    }

}
