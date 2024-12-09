using System.Buffers;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct CodeAttribute(ushort MaxStack, ushort MaxLocals, ReadOnlySequence<byte> Code, ExceptionHandlerTable ExceptionTable, AttributeTable Attributes)
    {

        public static CodeAttribute Nil => default;

        /// <summary>
        /// Attempts to read the code attribute starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
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

            if (ExceptionHandlerTable.TryRead(ref reader, out var exceptionTable) == false)
                return false;

            if (AttributeTable.TryRead(ref reader, out var attributes) == false)
                return false;

            attribute = new CodeAttribute(maxStack, maxLocals, code, exceptionTable, attributes);
            return true;
        }

        public readonly ushort MaxStack = MaxStack;
        public readonly ushort MaxLocals = MaxLocals;
        public readonly ReadOnlySequence<byte> Code = Code;
        public readonly ExceptionHandlerTable ExceptionTable = ExceptionTable;
        public readonly AttributeTable Attributes = Attributes;
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
        /// Copies this attribute to the specified attribute encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            // copy code to new blob
            var codeOffset = (int)Code.Length;
            var code = new BlobBuilder((int)Code.Length);
            new CodeDecoder(Code).CopyTo(constantView, constantPool, new CodeBuilder(code));

            // copy attribute table to new builder
            var attr = new AttributeTableBuilder(constantPool);
            Attributes.CopyTo(constantView, constantPool, attr);

            // add code attribute with copied values
            var excp = ExceptionTable;
            encoder.Code(constantPool.Get(AttributeName.Code), MaxStack, MaxLocals, code, e => excp.CopyTo(constantView, constantPool, ref e, codeOffset), attr);
        }

    }

}
