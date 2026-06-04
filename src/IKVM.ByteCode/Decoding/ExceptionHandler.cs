using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents an exception handler entry in the exception table of a <c>Code</c> attribute.
    /// </summary>
    /// <param name="StartOffset">The bytecode offset of the start of the protected region (inclusive).</param>
    /// <param name="EndOffset">The bytecode offset of the end of the protected region (exclusive).</param>
    /// <param name="HandlerOffset">The bytecode offset of the exception handler.</param>
    /// <param name="CatchType">The constant pool handle to the caught exception type, or the nil handle to catch all exceptions.</param>
    public readonly record struct ExceptionHandler(ushort StartOffset, ushort EndOffset, ushort HandlerOffset, ClassConstantHandle CatchType)
    {

        internal const int RecordSize = ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2;

        /// <summary>
        /// Attempts to measure the exception handler starting from the current position.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="size">The number of bytes read.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += RecordSize;
            if (reader.TryAdvance(RecordSize) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the exception handler starting from the current position.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="exceptionHandler">The decoded exception handler entry.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out ExceptionHandler exceptionHandler)
        {
            exceptionHandler = default;

            if (reader.TryReadU2(out ushort startOffset) == false)
                return false;
            if (reader.TryReadU2(out ushort endOffset) == false)
                return false;
            if (reader.TryReadU2(out ushort handlerOffset) == false)
                return false;
            if (reader.TryReadU2(out ushort catchTypeIndex) == false)
                return false;

            exceptionHandler = new ExceptionHandler(startOffset, endOffset, handlerOffset, new(catchTypeIndex));
            return true;
        }

        /// <summary>
        /// Encodes this exception handler to the specified table, offsetting any relative code locations.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        /// <param name="offset">The bytecode offset.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ExceptionTableEncoder encoder, int offset)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.Exception(
                checked((ushort)(StartOffset + offset)),
                checked((ushort)(EndOffset + offset)),
                checked((ushort)(HandlerOffset + offset)),
                constantPool.Get(constantView.Get(CatchType)));
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
        /// Gets the bytecode offset of the start of the protected region (inclusive).
        /// </summary>
        public readonly ushort StartOffset = StartOffset;

        /// <summary>
        /// Gets the bytecode offset of the end of the protected region (exclusive).
        /// </summary>
        public readonly ushort EndOffset = EndOffset;

        /// <summary>
        /// Gets the bytecode offset of the exception handler.
        /// </summary>
        public readonly ushort HandlerOffset = HandlerOffset;

        /// <summary>
        /// Gets the constant pool handle to the caught exception type, or the nil handle to catch all exceptions.
        /// </summary>
        public readonly ClassConstantHandle CatchType = CatchType;

    }

}
