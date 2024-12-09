using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LocalVariable(ushort StartPc, ushort Length, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, ushort Slot)
    {

        public readonly ushort StartPc = StartPc;
        public readonly ushort Length = Length;
        public readonly Utf8ConstantHandle Name = Name;
        public readonly Utf8ConstantHandle Descriptor = Descriptor;
        public readonly ushort Slot = Slot;
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
        /// Copies this variable to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref LocalVariableTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.LocalVariable(StartPc, Length, constantPool.Get(constantView.Get(Name)), constantPool.Get(constantView.Get(Descriptor)), Slot);
        }

    }

}
