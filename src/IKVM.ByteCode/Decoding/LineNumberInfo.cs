using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a line number entry decoded from the <c>LineNumberTable</c> attribute.
    /// </summary>
    /// <param name="StartPc">The bytecode offset at which the line begins.</param>
    /// <param name="LineNumber">The corresponding source line number.</param>
    public readonly record struct LineNumberInfo(ushort StartPc, ushort LineNumber)
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
        /// Gets the bytecode offset at which the line begins.
        /// </summary>
        public readonly ushort StartPc = StartPc;

        /// <summary>
        /// Gets the corresponding source line number.
        /// </summary>
        public readonly ushort LineNumber = LineNumber;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map">The stack map frame encoder.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool,ref LineNumberTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.LineNumber(StartPc, LineNumber);
        }

    }

}
