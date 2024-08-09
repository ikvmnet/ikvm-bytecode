using System;
using System.Buffers;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct CodeAttribute(ushort MaxStack, ushort MaxLocals, ReadOnlySequence<byte> Code, ExceptionHandlerTable ExceptionTable, AttributeTable Attributes)
    {

        public static CodeAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out CodeAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort maxStack) == false)
                return false;
            if (reader.TryReadU2(out ushort maxLocals) == false)
                return false;
            if (reader.TryReadU4(out uint codeLength) == false)
                return false;
            if (reader.TryReadMany(codeLength, out ReadOnlySequence<byte> code) == false)
                return false;

            if (reader.TryReadU2(out ushort exceptionTableLength) == false)
                return false;

            var exceptionTable = exceptionTableLength == 0 ? [] : new ExceptionHandler[exceptionTableLength];
            for (int i = 0; i < exceptionTableLength; i++)
            {
                if (reader.TryReadU2(out ushort startOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort endOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort handlerOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort catchTypeIndex) == false)
                    return false;

                exceptionTable[i] = new ExceptionHandler(startOffset, endOffset, handlerOffset, new(catchTypeIndex));
            }

            if (ClassFile.TryReadAttributeTable(ref reader, out var attributes) == false)
                return false;

            attribute = new CodeAttribute(maxStack, maxLocals, code, new(exceptionTable), attributes);
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="builder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, AttributeTableBuilder builder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var self = this;
            throw new NotImplementedException("Cannot import the Code attribute since we are currently unable to parse byte code.");

            //var b = new BlobBuilder();
            //var s = b.ReserveBytes((int)source.Code.Length);
            //source.Code.CopyTo(s.GetBytes());
            //builder.Code(source.MaxStack, source.MaxLocals, b, e => Import(source.ExceptionTable, ref e), Import(source.Attributes));
        }

    }

}
