using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ExceptionHandler(ushort StartOffset, ushort EndOffset, ushort HandlerOffset, ClassConstantHandle CatchType)
    {

        internal const int RecordSize = ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2;

        /// <summary>
        /// Attempts to measure the exception handler starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
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
        /// <param name="reader"></param>
        /// <param name="exceptionHandler"></param>
        /// <returns></returns>
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
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        /// <param name="offset"></param>
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

        public readonly ushort StartOffset = StartOffset;
        public readonly ushort EndOffset = EndOffset;
        public readonly ushort HandlerOffset = HandlerOffset;
        public readonly ClassConstantHandle CatchType = CatchType;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
