using System.Buffers;

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

    }

}
