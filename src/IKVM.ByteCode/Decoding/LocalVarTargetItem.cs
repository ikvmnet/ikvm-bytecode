using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a single item in a <c>localvar_target</c> type annotation target.
    /// </summary>
    /// <param name="Start">The bytecode offset at which the local variable scope begins.</param>
    /// <param name="Length">The length in bytes of the local variable's scope.</param>
    /// <param name="Index">The local variable slot index in the frame.</param>
    public readonly record struct LocalVarTargetItem(ushort Start, ushort Length, ushort Index)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out LocalVarTargetItem record)
        {
            record = default;

            if (reader.TryReadU2(out ushort start) == false)
                return false;
            if (reader.TryReadU2(out ushort length) == false)
                return false;
            if (reader.TryReadU2(out ushort index) == false)
                return false;

            record = new LocalVarTargetItem(start, length, index);
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
        /// Gets the bytecode offset at which the local variable scope begins.
        /// </summary>
        public readonly ushort Start = Start;

        /// <summary>
        /// Gets the length in bytes of the local variable's scope.
        /// </summary>
        public readonly ushort Length = Length;

        /// <summary>
        /// Gets the local variable slot index in the frame.
        /// </summary>
        public readonly ushort Index = Index;

        /// <summary>
        /// Copies this item to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref LocalVarTargetTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            WriteTo(ref encoder);
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="map">The stack map frame encoder.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void WriteTo(ref LocalVarTargetTableEncoder encoder)
        {
            encoder.LocalVar(Start, Length, Index);
        }

    }

}
